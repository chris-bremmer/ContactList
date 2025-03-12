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

		public UsersController(ApplicationDbContext context)
		{
			_context = context;
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
			HttpContext.Session.Clear();
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
					// Store user information in session
					HttpContext.Session.SetInt32("UserId", user.UserId);
					HttpContext.Session.SetString("UserEmail", user.Email);

					return RedirectToAction(nameof(Index), "Home");
				}
			}

				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(userLogin);
		}
	}
}