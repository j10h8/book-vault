using book_vault.Models;

namespace book_vault.Repositories
{
	public interface IUserRepository
	{
		Task<UserModel?> LogInAsync(LogInModel logInModel);
		Task<bool> CreateVaultAsync(CreateVaultModel createVaultModel);
		Task<UserModel?> GetUserByIdAsync(int id);
		Task DeleteVaultAsync(string userName);
	}
}
