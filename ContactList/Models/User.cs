using ContactList.Utility;
using System.ComponentModel.DataAnnotations;

namespace ContactList.Models
{
	public class User
	{

		private string _password;
		private Crypto _crypto;

		public User()
		{
			_crypto = new Crypto();
			Contacts = new List<Contact>();
		}

		[Key]
		public int UserId { get; set; }

		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100)]
		public string LastName { get; set; }

		[Required]
		[StringLength(100)]
		public string Email { get; set; }

		[Required]
		[StringLength(100)]
		public string Password 
		{ 
			get { return _password; } 
			set { _password = _crypto.Encrypt(value); } 
		}

		public ICollection<Contact> Contacts { get; set; }
	}
}
