using book_vault.Models;
using Microsoft.AspNetCore.Components;

namespace book_vault.Pages
{
	public partial class UserPage
	{
		[Parameter]
		public string? UserName { get; set; }
		private UserModel? _loggedInUser;
		private int _loggedInUserId;
		private AddBookModel AddBookModel { get; set; } = new();
		private bool _isSortedByTitle = true;
		private string _sortButtonText = "author";
		private List<BookModel> BooksList { get; set; } = null!;

		protected async override Task OnInitializedAsync()
		{
			var result = await SessionStorage.GetAsync<int>("LoggedInUserId");

			if (result.Success)
			{
				_loggedInUserId = result.Value;
			}

			_loggedInUser = await UserService.GetUserByIdAsync(_loggedInUserId);

			SetBooksList();
		}

		private void FilterList(string? searchString)
		{
			if (string.IsNullOrEmpty(searchString))
			{
				SetBooksList();
			}
			else
			{
				if (_loggedInUser != null && _loggedInUser.Books != null && _loggedInUser.Books.Count() > 0)
				{
					if (_isSortedByTitle)
					{
						BooksList = _loggedInUser.Books.Where(book => book.Title.ToLower().Contains(searchString.ToLower()) || book.Author.ToLower().Contains(searchString.ToLower())).OrderBy(book => book.Title).ToList();
					}
					else
					{
						BooksList = _loggedInUser.Books.Where(book => book.Title.ToLower().Contains(searchString.ToLower()) || book.Author.ToLower().Contains(searchString.ToLower())).OrderBy(book => book.Author).ToList();
					}
				}
			}
		}

		private void SetBooksList()
		{
			if (_loggedInUser != null && _loggedInUser.Books != null)
			{
				if (_isSortedByTitle)
				{
					BooksList = _loggedInUser.Books.OrderBy(book => book.Title).ToList();
				}
				else
				{
					BooksList = _loggedInUser.Books.OrderBy(book => book.Author).ToList();
				}
			}
		}

		private async Task HandleSubmitAsync()
		{
			if (_loggedInUser != null)
			{
				await BookService.AddBookAsync(AddBookModel, _loggedInUser);

				SetBooksList();

				AddBookModel = new AddBookModel();
			}
		}

		private void ChangeOrderBy()
		{
			if (_loggedInUser != null && _loggedInUser.Books != null && _loggedInUser.Books.Count() > 0)
			{
				if (_isSortedByTitle)
				{
					_isSortedByTitle = false;

					_sortButtonText = "title";

					SetBooksList();

					FilterList("");
				}
				else
				{
					_isSortedByTitle = true;

					_sortButtonText = "author";

					SetBooksList();

					FilterList("");
				}
			}
		}

		private void ReRenderUserPage()
		{
			SetBooksList();

			StateHasChanged();
		}

		private async Task RemoveBookAsync(int bookId)
		{
			if (_loggedInUser != null)
			{
				await BookService.RemoveBookAsync(bookId, _loggedInUser.UserName);

				SetBooksList();

				StateHasChanged();
			}
		}

		private void NavigateToIndexPage()
		{
			navigationManager.NavigateTo("/");
		}
	}
}
