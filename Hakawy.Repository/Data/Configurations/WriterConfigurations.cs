using Hakawy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakawy.Repository.Data.Configurations
{
	public class WriterConfigurations : IEntityTypeConfiguration<Writer>
	{
		public void Configure(EntityTypeBuilder<Writer> builder)
		{

			builder.HasKey(w => w.Id);

			builder.Property(w => w.Email)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(w => w.PreferedLanguage)
				.HasMaxLength(50);

			builder.Property(w => w.WritingStyle)
				.HasMaxLength(50);

			// Relationship: One Writer has many Stories
			builder.HasMany(w => w.Stories)
				.WithOne(s => s.Writer)
				.HasForeignKey(s => s.WriterId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
