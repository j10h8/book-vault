using System.ComponentModel.DataAnnotations;

namespace book_vault.Models
{
	public class AddBookModel
	{
		[Required(ErrorMessage = "Please provide the book's title!")]
		public string Title { get; set; } = null!;
		[Required(ErrorMessage = "Please provide the book's author!")]
		public string Author { get; set; } = null!;
	}
}
