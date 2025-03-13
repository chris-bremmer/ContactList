using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Data;
using ContactList.Models;

namespace ContactList.Controllers
{
	public class ContactsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ContactsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Contacts
		public async Task<IActionResult> Contacts()
		{
			var contacts = await _context.Contacts.Include(c => c.User).ToListAsync();
			return View(contacts);
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
			contact.UserId = (int)HttpContext.Session.GetInt32("UserId");
			if (ModelState.IsValid)
			{
				_context.Add(contact);
				await _context.SaveChangesAsync();
				return View("Contacts");
			}
			return View(contact);
		}

		private int GetUserId()
		{
			return HttpContext.Session.GetInt32("UserId") ?? 0;
		}

	}
}
