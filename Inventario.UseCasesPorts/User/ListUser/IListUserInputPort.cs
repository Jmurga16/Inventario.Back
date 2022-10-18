using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.User.ListUser
{
    public interface IListUserInputPort
    {

        //IEnumerable<Menu> GetMenus();
        Task GetUsers();
        //Task GetUserById();

    }
}
