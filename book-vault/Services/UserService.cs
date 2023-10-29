using book_vault.Models;
using book_vault.Repositories;

namespace book_vault.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;

		public UserService(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public async Task<UserModel?> LogInAsync(LogInModel logInModel)
		{
			return await userRepository.LogInAsync(logInModel);
		}

		public async Task<bool> CreateVaultAsync(CreateVaultModel createVaultModel)
		{
			return await userRepository.CreateVaultAsync(createVaultModel);
		}

		public async Task<UserModel?> GetUserByIdAsync(int id)
		{
			return await userRepository.GetUserByIdAsync(id);
		}

		public async Task DeleteVaultAsync(string userName)
		{
			await userRepository.DeleteVaultAsync(userName);
		}
	}
}
