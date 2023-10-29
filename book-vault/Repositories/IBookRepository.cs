using book_vault.Models;

namespace book_vault.Repositories
{
	public interface IBookRepository
	{
		Task AddBookAsync(AddBookModel addBookModel, UserModel userModel);
		Task UpdateBookAsync(BookModel bookToUpdate, UpdateBookModel updateBookModel);
		Task RemoveBookAsync(int bookId, string userName);
	}
}
