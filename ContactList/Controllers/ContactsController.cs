using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactList.Data;
using ContactList.Models;
using ContactList.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Controllers
{
	public class ContactsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly DBSession _session;

		public ContactsController(ApplicationDbContext context)
		{
			_context = context;
			_session = new DBSession(context);
		}

		// GET: Contacts
		public async Task<IActionResult> Contacts(string? searchString)
		{
			int userId = GetUserId();
			var contactsQuery = _context.Contacts.Where(c => c.UserId == userId && c.IsActive && c.Favourite);

			if (!string.IsNullOrEmpty(searchString))
			{
				contactsQuery = contactsQuery.Where(c => c.Name.Contains(searchString) || c.Email.Contains(searchString) || c.Phone.Contains(searchString));
			}

			var contacts = await contactsQuery.ToListAsync();
			ContactListViewModel model = new ContactListViewModel(contacts)
			{
				Favourites = true,
				Active = true
			};

			return View(model);
		}

		// POST: Contacts
		[HttpPost]
		public async Task<IActionResult> Contacts(bool favourites, bool active, string? searchString)
		{
			int userId = GetUserId();
			var contactsQuery = _context.Contacts.Where(c => c.UserId == userId && c.IsActive == active && c.Favourite == favourites);

			if (!string.IsNullOrEmpty(searchString))
			{
				contactsQuery = contactsQuery.Where(c => c.Name.Contains(searchString) || c.Email.Contains(searchString) || c.Phone.Contains(searchString));
			}

			var contacts = await contactsQuery.ToListAsync();
			ContactListViewModel model = new ContactListViewModel(contacts)
			{
				Favourites = favourites,
				Active = active
			};

			return View(model);
		}

		// GET: Edit
		[Route("Contacts/Edit/{contactId}")]
		public IActionResult Edit(int contactId)
		{
			var contact = _context.Contacts.FirstOrDefault(c => c.ContactId == contactId && c.UserId == GetUserId());
			return View(contact);
		}

		// POST: Edit
		[Route("Contacts/Edit/{contactId}")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Contact contact)
		{
			contact.Modified = DateTime.Now;
			_context.Attach(contact).State = EntityState.Modified;
			if (ModelState.IsValid)
			{
				_context.SaveChanges();
				return RedirectToAction(nameof(Contacts));
			}
			return View(contact);
		}

		// GET: Delete
		[Route("Contacts/Delete/{contactId}")]
		public async Task<IActionResult> Delete(int contactId)
		{
			var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == contactId && c.UserId == GetUserId());

			if (contact != null)
			{
				_context.Contacts.Remove(contact);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Contacts));
		}

		// GET: Details
		[Route("Contacts/Details/{contactId}")]
		public IActionResult Details(int contactId)
		{
			var contact = _context.Contacts.FirstOrDefault(c => c.ContactId == contactId && c.UserId == GetUserId());

			if (contact != null)
			{
				_session.Set(GetUserId(), "ContactID", contactId.ToString());
				_session.Set(GetUserId(), "ContactName", contact.Name);
			}

			return View(contact);
		}

		// GET: Create
		public IActionResult Create()
		{
			var contact = new Contact
			{
				IsActive = true // Set default value
			};
			return View(contact);
		}

		// POST: Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Contact contact)
		{
			contact.Created = DateTime.Now;
			contact.Modified = DateTime.Now;
			contact.UserId = GetUserId();
			if (ModelState.IsValid)
			{
				_context.Add(contact);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Contacts));
			}
			return View(contact);
		}

		/// <summary>
		/// Return a user id of the logged in user.
		/// If there is none, then direct to login, 
		/// since being logged in is required for most everything on this page.
		/// </summary>
		/// <returns>The ID of the logged in user</returns>
		private int GetUserId()
		{
			int result = 0;
			string? userId = HttpContext.Request.Cookies["UserId"];
			if (userId != null)
			{
				int.TryParse(userId, out result);
			}
			if (result == 0)
			{
				var loginUrl = Url.Action("Login", "Users").ToString();
				Response.Redirect(loginUrl);
			}
			return result;
		}
	}
}