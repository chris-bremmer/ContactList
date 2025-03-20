using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Data;
using ContactList.Models;
using System;
using ContactList.Utility;

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
		public async Task<IActionResult> Contacts()
		{
			int userId = GetUserId();
			var contacts = await _context.Contacts.Where(c => c.UserId == userId & (c.IsActive == true & c.Favourite == true)).ToListAsync();
			ContactListViewModel model = new ContactListViewModel(contacts);
			model.Favourites = true;
			model.Active = true;	

			return View(model);
		}

		// GET: Contacts
		[HttpPost]
		public async Task<IActionResult> Contacts(bool favourites, bool active)
		{
			int userId = GetUserId();
			var contacts = await _context.Contacts.Where(c => c.UserId == userId & (c.IsActive == active & c.Favourite == favourites)).ToListAsync();
			ContactListViewModel model = new ContactListViewModel(contacts);
			model.Favourites = favourites;
			model.Active = active;

			return View(model);
		}


		// GET: Edit
		[Route("Contacts/Edit/{contactId}")]
		public IActionResult Edit(int contactId)
		{
			var contact = _context.Contacts.Where(c => c.ContactId == contactId & c.UserId == GetUserId()).FirstOrDefault();

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
				return RedirectToAction(nameof(Contacts), "Contacts");
			}
			return View(contact);
		}


		// GET: Delete
		[Route("Contacts/Delete/{contactId}")]
		public async Task<IActionResult> Delete(int contactId)
		{
			var contact = await _context.Contacts
		.Where(c => c.ContactId == contactId && c.UserId == GetUserId())
		.FirstOrDefaultAsync();

			if (contact != null)
			{
				_context.Contacts.Remove(contact);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Contacts), "Contacts");
		}


		// GET: Details
		[Route("Contacts/Details/{contactId}")]
		public IActionResult Details(int contactId)
		{
			var contact = _context.Contacts.Where(c =>
				c.ContactId == contactId &
				c.UserId == GetUserId()).FirstOrDefault();

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
				return RedirectToAction(nameof(Contacts), "Contacts");
			}
			return View(contact);
		}

		private int GetUserId()
		{
			int result = 0;
			string? userId = HttpContext.Request.Cookies["UserId"];
			if (userId != null)
			{
				int.TryParse(userId, out result);
			}
			return result;
		}

	}
}
