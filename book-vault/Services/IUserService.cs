using book_vault.Models;

namespace book_vault.Services
{
	public interface IUserService
	{
		Task<UserModel?> LogInAsync(LogInModel logInModel);
		Task<bool> CreateVaultAsync(CreateVaultModel createVaultModel);
		Task<UserModel?> GetUserByIdAsync(int id);
		Task DeleteVaultAsync(string userName);
	}
}
