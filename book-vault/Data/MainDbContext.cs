using book_vault.Models;
using Microsoft.EntityFrameworkCore;

namespace book_vault.Data
{
	public class MainDbContext : DbContext
	{
		public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
		{

		}

		public DbSet<UserModel> Users { get; set; }

		public DbSet<BookModel> Books { get; set; }
	}
}
