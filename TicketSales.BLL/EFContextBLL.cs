using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.BLL.Abstract;
using TicketSales.BLL.Concrete;
using TicketSales.DAL;

namespace TicketSales.BLL
{
    public static class EFContextBLL
    {
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopeDAL();
            services.AddScoped<IUserBLL, UserService>();
            services.AddScoped<ICityBll, CityService>();
            services.AddScoped<ICategoryBLL, CategoryService>();
            services.AddScoped<IEventBLL, EventService>();
        }
    }
}
