using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList.Models
{
	public class PhoneNumber
	{
		[Key]
		public int PhoneId { get; set; }

		[Required]
		[StringLength(25)]
		public string Phone { get; set; }

		[Required]
		[ForeignKey("PhoneType")]
		public int PhoneTypeId { get; set; }

		[Required]
		[ForeignKey("Contact")]
		public int ContactId { get; set; }
	}
}
