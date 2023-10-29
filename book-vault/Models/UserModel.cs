using System.ComponentModel.DataAnnotations;

namespace book_vault.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string UserName { get; set; } = null!;
		[Required]
		public string Password { get; set; } = null!;
		public List<BookModel>? Books { get; set; }
	}
}
