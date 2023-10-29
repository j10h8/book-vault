using System.ComponentModel.DataAnnotations;

namespace book_vault.Models
{
	public class UpdateBookModel
	{
		[Required(ErrorMessage = "Please provide the book's title!")]
		public string UpdateTitle { get; set; } = null!;
		[Required(ErrorMessage = "Please provide the book's author!")]
		public string UpdateAuthor { get; set; } = null!;
	}
}
