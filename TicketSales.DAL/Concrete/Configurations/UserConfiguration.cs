using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Model.Entities;

namespace TicketSales.DAL.Concrete.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Email).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Password).HasMaxLength(20).IsRequired();
            builder.Property(a => a.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(100).IsRequired();
            builder.HasIndex(a => a.Email).IsUnique();
        }
    }
}
