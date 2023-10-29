using book_vault.Data;
using book_vault.Models;
using Microsoft.EntityFrameworkCore;

namespace book_vault.Repositories
{
	public class BookRepository : IBookRepository
	{
		private readonly MainDbContext mainDbContext;

		public BookRepository(MainDbContext mainDbContext)
		{
			this.mainDbContext = mainDbContext;
		}

		public async Task AddBookAsync(AddBookModel addBookModel, UserModel userModel)
		{
			var user = await mainDbContext.Users
				.Include(user => user.Books)
				.Where(user => user.Id == userModel.Id)
				.FirstOrDefaultAsync();

			if (user != null)
			{
				if (user.Books == null)
				{
					user.Books = new List<BookModel>();
				}

				var bookModel = new BookModel
				{
					Title = addBookModel.Title,
					Author = addBookModel.Author
				};

				user.Books.Add(bookModel);

				await mainDbContext.SaveChangesAsync();
			}
		}

		public async Task RemoveBookAsync(int bookId, string userName)
		{
			var bookToRemove = await mainDbContext.Books
				.Where(book => book.Id == bookId)
				.FirstOrDefaultAsync();

			if (bookToRemove != null)
			{
				mainDbContext.Books.Remove(bookToRemove);
			}

			await mainDbContext.SaveChangesAsync();
		}

		public async Task UpdateBookAsync(BookModel bookToUpdate, UpdateBookModel updateBookModel)
		{
			bookToUpdate.Title = updateBookModel.UpdateTitle;
			bookToUpdate.Author = updateBookModel.UpdateAuthor;

			await mainDbContext.SaveChangesAsync();
		}
	}
}
