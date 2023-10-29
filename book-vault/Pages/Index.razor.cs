using book_vault.Models;

namespace book_vault.Pages
{
	public partial class Index
	{
		private LogInModel LogInModel { get; set; } = new();
		private UserModel? _userFromDb;
		private CreateVaultModel CreateVaultModel { get; set; } = new();
		private bool messageModalIsVisible = false;
		private string? _message;

		private async Task HandleUnlockVaultAsync()
		{
			_userFromDb = await UserService.LogInAsync(LogInModel);

			if (_userFromDb != null)
			{
				await SessionStorage.SetAsync("LoggedInUserId", _userFromDb.Id);
				await SessionStorage.SetAsync("UserName", _userFromDb.UserName);

				NavigationManager.NavigateTo($"userpage/{_userFromDb.UserName}", true);
			}
			else
			{
				_message = "Log in failed! Please provide a user name and password and try again";
				messageModalIsVisible = true;
			}
		}

		private async Task HandleCreateVaultAsync()
		{
			if (await UserService.CreateVaultAsync(CreateVaultModel))
			{
				_message = "A new vault has been created!";
				messageModalIsVisible = true;
				CreateVaultModel = new CreateVaultModel();
			}
			else
			{
				_message = "A new vault could not be created! Choose a username with at least two characters and a password with at least 8 characters! Also, the username may be unavailable!";
				messageModalIsVisible = true;
			}
		}

		private void ToggleMessageModal()
		{
			messageModalIsVisible = !messageModalIsVisible;

			StateHasChanged();
		}
	}
}
