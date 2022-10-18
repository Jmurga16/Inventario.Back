using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.Inventory.ListInventory
{
    public interface IListInventoryInputPort
    {
        Task GetInventory();
        Task GetInventoryById(int nOpcion, int nIdProducto);

    }
}
