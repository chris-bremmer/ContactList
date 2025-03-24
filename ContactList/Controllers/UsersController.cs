using ContactList.Data;
using ContactList.Models;
using ContactList.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ContactList.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly DBSession _session;

		public UsersController(ApplicationDbContext context)
		{
			_context = context;
			_session = new DBSession(context);
		}

		// GET: Users/Register
		public IActionResult Register()
		{
			return View();
		}

		// POST: Users/Register
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(User user)
		{
			if (ModelState.IsValid)
			{
				_context.Add(user);
				await _context.SaveChangesAsync();
				return View("Login");
			}
			return View(user);
		}


		// GET: Users/Logout
		public IActionResult Logout()
		{
			_session.Clear(GetUserId());
			HttpContext.Response.Cookies.Delete("UserID");
			return RedirectToAction(nameof(Index), "Home");
		}

		// GET: Users/Login
		public IActionResult Login()
		{
			return View();
		}

		// POST: Users/Login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserLogin userLogin)
		{
			if (ModelState.IsValid)
			{
				var user = await _context.Users
					.Where(u => u.Email == userLogin.Email)
					.FirstOrDefaultAsync();
				if (user != null && user.UserId > 0 && user.Password == new Crypto().Encrypt(userLogin.Password))
				{
					//Clear any existing session data
					_session.Clear(user.UserId);
					// Store user information in session
					_session.Set(user.UserId, "UserEmail", user.Email);
					_session.Set(user.UserId, "UserId", user.UserId.ToString());
					var cookieOptions = new CookieOptions
					{
						Path = "/",
						Secure = false,
						SameSite = SameSiteMode.Lax
					};
					HttpContext.Response.Cookies.Append("UserID", user.UserId.ToString(), cookieOptions);
					return RedirectToAction(nameof(Index), "Home");
				}
			}

				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(userLogin);
		}

		private int GetUserId()
		{
			int result = 0;
			string ?userId = HttpContext.Request.Cookies["UserId"];
			if (userId != null)
			{
				int.TryParse(userId, out result);
			}
			return result;
		}
	}
}