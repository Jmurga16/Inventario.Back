using Inventario.UseCasesDTOs.Inventory.ListInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.Inventory.ListInventory
{
    public interface IListInventoryOutputPort
    {
        Task Handle(IEnumerable<ListInventoryResponse> Inventory);
    }
}
