using Microsoft.EntityFrameworkCore;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Data
{
	public static class ModelBuilders
	{
		public static ModelBuilder SeedData(this ModelBuilder builder)
		{
			builder.Entity<User>()
				.HasData(
					new User { IdUser = 1, Name = "admin", Email = "admin@ubistart.com", IsAdmin = true, Password = "123456" }
				);
			return builder;
		}
	}
}
