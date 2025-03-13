using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ContactList.Models
{
	public class Contact
	{
		[Key]
		public int ContactId { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "Full Name")]
		public string Name { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "Email Address")]
		public string Email { get; set; }

		[Required]
		[StringLength(15)]
		[Display(Name = "Phone Number")]
		public string Phone { get; set; }

		[DefaultValue(false)]
		public bool Favourite { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; } = true;

		[Required]
		public DateTime Created { get; set; } = DateTime.Now;

		[Required]
		public DateTime Modified { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

	}
}
