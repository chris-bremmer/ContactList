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
			int userId = GetUserId();
			var contacts = await _context.Contacts.Where(c => c.UserId == userId).ToListAsync();
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
		// GET: Edit
		[Route("Contacts/Edit/{contactId}")]
		public IActionResult Edit(int contactId)
		{
			var contact = _context.Contacts.Where(c => c.ContactId == contactId & c.UserId == GetUserId()).FirstOrDefault();

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
