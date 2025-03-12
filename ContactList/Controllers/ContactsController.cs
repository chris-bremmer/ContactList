using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ContactList.Data;

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
		public async Task<IActionResult> Index()
		{
			var contacts = await _context.Contacts.Include(c => c.User).ToListAsync();
			return View(contacts);
		}

	}
}
