using ContactList.Controllers;
using ContactList.Data;
using ContactList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ContactList.Tests
{
	public class ContactsControllerTests
	{
		private readonly ContactsController _controller;
		private readonly ApplicationDbContext _context;

		public ContactsControllerTests()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;

			_context = new ApplicationDbContext(options);

			_controller = new ContactsController(_context)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
				}
			};
		}

		[Fact]
		public async Task Contacts_ReturnsViewResult_WithListOfContacts()
		{
			// Arrange
			int userId = 1;
			var cookies = new Mock<IRequestCookieCollection>();
			cookies.Setup(c => c["UserId"]).Returns(userId.ToString());
			_controller.ControllerContext.HttpContext.Request.Cookies = cookies.Object;

			var contacts = new List<Contact>
		{
			new Contact { ContactId = 1, Name = "John Doe", Email = "john@doe.com", Phone = "250 809-5154", UserId = userId, IsActive = true, Favourite = true },
			new Contact { ContactId = 2, Name = "Jane Doe", Email = "jane@doe.com", Phone = "250 809-5254", UserId = userId, IsActive = true, Favourite = true }
		};

			_context.Contacts.AddRange(contacts);
			_context.SaveChanges();

			// Act
			var result = await _controller.Contacts("");

			// Assert
			var viewResult = Assert.IsType<ViewResult>(result);
			var model = Assert.IsAssignableFrom<ContactListViewModel>(viewResult.ViewData.Model);
			Assert.Equal(2, model.Contacts.Count());
		}

		[Fact]
		public async Task Create_Post_ValidContact_RedirectsToContacts()
		{
			// Arrange
			int userId = 1;
			var cookies = new Mock<IRequestCookieCollection>();
			cookies.Setup(c => c["UserId"]).Returns(userId.ToString());
			_controller.ControllerContext.HttpContext.Request.Cookies = cookies.Object;

			var contact = new Contact
			{
				ContactId = 3,
				Name = "Russ Doe",
				Email = "russ@doe.com",
				Phone = "250 809-5354",
				UserId = userId,
				IsActive = true,
				Favourite = true,
				Created = DateTime.Now,
				Modified = DateTime.Now
			};

			// Act
			var result = await _controller.Create(contact);

			// Assert
			var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
			Assert.Equal("Contacts", redirectToActionResult.ActionName);
		}

	}
}