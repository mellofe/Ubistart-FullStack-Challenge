using Microsoft.EntityFrameworkCore;
using Ubistart_FullStack_Challenge.Data.Mappings;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Data.Context
{
	public class SqlContext : DbContext
	{
		public SqlContext(DbContextOptions<SqlContext> options)
			: base(options) { }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMap());
			modelBuilder.ApplyConfiguration(new TaskMap());
			modelBuilder.SeedData();
			base.OnModelCreating(modelBuilder);
		}
	}
}
