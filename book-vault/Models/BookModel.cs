using System.ComponentModel.DataAnnotations;

namespace book_vault.Models
{
	public class BookModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = null!;
		[Required]
		public string Author { get; set; } = null!;
	}
}
