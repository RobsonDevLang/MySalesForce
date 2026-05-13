using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using usersService.Models;

namespace usersService.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
        
    }
}