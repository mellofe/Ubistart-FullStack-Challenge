using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Data.Mappings
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.IdUser).IsRequired();
			builder.Property(x => x.Name).IsRequired();
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.Password).IsRequired();
			builder.Property(x => x.IsAdmin).HasDefaultValue(false);
		}
	}
}
