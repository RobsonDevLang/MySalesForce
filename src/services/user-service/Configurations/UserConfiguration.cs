using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Models;

namespace UserService.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
        
    }
}