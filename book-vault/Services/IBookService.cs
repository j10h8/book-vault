using book_vault.Models;

namespace book_vault.Services
{
	public interface IBookService
	{
		Task AddBookAsync(AddBookModel addBookModel, UserModel userModel);
		Task UpdateBookAsync(BookModel bookToUpdate, UpdateBookModel updateBookModel);
		Task RemoveBookAsync(int bookId, string userName);
	}
}
