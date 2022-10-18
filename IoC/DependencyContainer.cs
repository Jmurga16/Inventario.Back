using Inventario.ADONet;
using Inventario.UseCases.Login;
using Inventario.UseCases.Menu.ListMenu;
using Inventario.UseCases.Users.FormUser;
using Inventario.UseCases.Users.ListUser;
using Inventario.UseCasesPorts.Inventory.FormInventory;
using Inventario.UseCasesPorts.Inventory.ListInventory;
using Inventario.UseCasesPorts.Login;
using Inventario.UseCasesPorts.Menu.ListMenu;
using Inventario.UseCasesPorts.User.FormUser;
using Inventario.UseCasesPorts.User.ListUser;
using Inventory.UseCases.Inventory.FormInventory;
using Inventory.UseCases.Inventory.ListInventory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.Inventory.FormInventory;
using Presenters.Inventory.ListInventory;
using Presenters.Login;
using Presenters.Menu.ListMenu;
using Presenters.User.FormUser;
using Presenters.User.ListUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    //Clase de Inyección de Dependencias
    public static class DependencyContainer
    {
        public static IServiceCollection AddInventoryServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<Conexion>();            

            services.AddScoped<IListMenuInputPort, ListMenuInteractor>();
            services.AddScoped<IListMenuOutputPort, ListMenuPresenter>();

            services.AddScoped<IListUserInputPort, ListUserInteractor>();
            services.AddScoped<IListUserOutputPort, ListUserPresenter>();

            services.AddScoped<IFormUserInputPort, FormUserInteractor>();
            services.AddScoped<IFormUserOutputPort, FormUserPresenter>();

            services.AddScoped<ILoginInputPort, LoginInteractor>();
            services.AddScoped<ILoginOutputPort, LoginPresenter>();

            services.AddScoped<IListInventoryInputPort, ListInventoryInteractor>();
            services.AddScoped<IListInventoryOutputPort, ListInventoryPresenter>();

            services.AddScoped<IFormInventoryInputPort, FormInventoryInteractor>();
            services.AddScoped<IFormInventoryOutputPort, FormInventoryPresenter>();

            return services;
        }
    }
}
