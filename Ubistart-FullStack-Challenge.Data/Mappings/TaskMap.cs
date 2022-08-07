using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubistart_FullStack_Challenge.Domain.Entities;

namespace Ubistart_FullStack_Challenge.Data.Mappings
{
	public class TaskMap : IEntityTypeConfiguration<Task>
	{
		public void Configure(EntityTypeBuilder<Task> builder)
		{
			builder.Property(x => x.Description).IsRequired();
			builder.Property(x => x.Deadline).IsRequired();
		}
	}
}
