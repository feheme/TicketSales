using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.DAL.Abstract;
using TicketSales.DAL.Concrete.Repositories;

namespace TicketSales.DAL
{
    public static class EFContextDAL
    {
        public static void AddScopeDAL(this IServiceCollection services)
        {
            services.AddScoped<IUserDAL, UserRepository>();
            services.AddScoped<ICityDAL, CityRepository>();
            services.AddScoped<ICategoryDAL, CategoryRepository>();
            services.AddScoped<IEventDAL, EventRepository>();
        }
    }
}
