using book_vault.Data;
using book_vault.Models;
using Microsoft.EntityFrameworkCore;

namespace book_vault.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly MainDbContext mainDbContext;

		public UserRepository(MainDbContext mainDbContext)
		{
			this.mainDbContext = mainDbContext;
		}

		public async Task<bool> CreateVaultAsync(CreateVaultModel createVaultModel)
		{
			if (createVaultModel.UserName != null && createVaultModel.Password != null && createVaultModel.UserName.Length > 1 && createVaultModel.Password.Length > 7)
			{
				if (await mainDbContext.Users.AnyAsync(user => user.UserName == createVaultModel.UserName))
				{
					return false;
				}

				mainDbContext.Users.Add(new UserModel
				{
					UserName = createVaultModel.UserName,
					Password = createVaultModel.Password
				});

				if (await mainDbContext.SaveChangesAsync() > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public async Task DeleteVaultAsync(string userName)
		{
			var user = await mainDbContext.Users
				.Include(user => user.Books)
				.Where(user => user.UserName == userName)
				.FirstOrDefaultAsync();

			if (user != null)
			{
				mainDbContext.Users.Remove(user);

				if (user.Books != null && user.Books.Count() > 0)
				{
					mainDbContext.Books.RemoveRange(user.Books);
				}

				await mainDbContext.SaveChangesAsync();
			}
		}

		public async Task<UserModel?> GetUserByIdAsync(int id)
		{
			return await mainDbContext.Users
				.Include(user => user.Books)
				.Where(user => user.Id == id)
				.FirstOrDefaultAsync();
		}

		public async Task<UserModel?> LogInAsync(LogInModel logInModel)
		{
			return await mainDbContext.Users
				.Include(user => user.Books)
				.Where(user => user.UserName == logInModel.UserName && user.Password == logInModel.Password)
				.FirstOrDefaultAsync();
		}
	}
}
