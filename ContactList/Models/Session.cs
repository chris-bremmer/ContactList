using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ContactList.Models
{
	public class Session
	{
		[Key]
		[Required]
		public int SessionId { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		[StringLength(100)]
		public string Key { get; set; }

		[Required]
		[StringLength(1000)]
		public string Value { get; set; }

		[Required]
		public DateTime Updated { get; set; }

	}
}
