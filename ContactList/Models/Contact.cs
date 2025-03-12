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
		public string Name { get; set; }

		[Required]
		[StringLength(100)]
		public string Email { get; set; }

		[Required]
		[StringLength(15)]
		public string Phone { get; set; }

		[DefaultValue(false)]
		public bool Favourite { get; set; }

		public bool IsActive { get; set; } = true;

		[Required]
		public DateTime Created { get; set; } = DateTime.Now;

		[Required]
		public DateTime Modified { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }

		public User User { get; set; }
	}
}
