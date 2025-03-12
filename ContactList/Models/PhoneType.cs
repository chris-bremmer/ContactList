using System.ComponentModel.DataAnnotations;

namespace ContactList.Models
{
	public class PhoneType
	{
		[Key]		
		public int PhoneTypeId { get; set; }

		[Required]
		[StringLength(100)]
		public string PhoneTypeName { get; set; }

		public bool IsMobile { get; set; }

	}
}
