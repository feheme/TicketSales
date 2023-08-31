using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Model.Entities;
using TicketSales.Model.Enums;

namespace TicketSales.DAL.Concrete.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                ID = 1,
                FirstName = "Marty",
                LastName = "McFly",
                Email = "akb@mail.com",
                Password = "123",
                Role = UserRole.Admin,
                IsActive = true
            });
        }
    }
}
