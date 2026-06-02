using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Size.Models;

namespace Product.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<SizeModel>
    {
        public void Configure(EntityTypeBuilder<SizeModel> builder)
        {
            builder.ToTable("size");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Size)
                .HasColumnName("size")
                .HasMaxLength(255);
        }
    }
}