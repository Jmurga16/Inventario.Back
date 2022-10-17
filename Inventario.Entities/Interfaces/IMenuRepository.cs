using Inventario.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.Interfaces
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetMenus();
    }
}
