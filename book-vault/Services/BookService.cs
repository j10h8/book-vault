using book_vault.Models;
using book_vault.Repositories;

namespace book_vault.Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepository bookRepository;

		public BookService(IBookRepository bookRepository)
		{
			this.bookRepository = bookRepository;
		}

		public async Task AddBookAsync(AddBookModel addBookModel, UserModel userModel)
		{
			await bookRepository.AddBookAsync(addBookModel, userModel);
		}

		public async Task UpdateBookAsync(BookModel bookToUpdate, UpdateBookModel updateBookModel)
		{
			await bookRepository.UpdateBookAsync(bookToUpdate, updateBookModel);
		}

		public async Task RemoveBookAsync(int bookId, string userName)
		{
			await bookRepository.RemoveBookAsync(bookId, userName);
		}
	}
}
