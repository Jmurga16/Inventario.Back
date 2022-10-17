using Inventario.ADONet;
using Inventario.UseCases.Menu.ListMenu;
using Inventario.UseCasesPorts.Menu.ListMenu;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.Menu.ListMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInventoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<Conexion>(options => options.UseSqlServer(configuration.GetConnectionString("connectionString")));

            services.AddScoped<Conexion>();
            

            services.AddScoped<IListMenuInputPort, ListMenuInteractor>();
            services.AddScoped<IListMenuOutputPort, ListMenuPresenter>();

            //services.AddScoped<IListUserSummaryByDateInputPort, ListUserSummaryByDateInteractor>();

            return services;
        }
    }
}
