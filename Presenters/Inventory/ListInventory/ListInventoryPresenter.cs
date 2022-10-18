using Inventario.UseCasesDTOs.Inventory.ListInventory;
using Inventario.UseCasesPorts.Inventory.ListInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Inventory.ListInventory
{
    public class ListInventoryPresenter : IListInventoryOutputPort, IPresenter<IEnumerable<ListInventoryResponse>>
    {
        public IEnumerable<ListInventoryResponse> Content { get; private set; }
    
        public Task Handle(IEnumerable<ListInventoryResponse> Inventory)
        {
            Content = Inventory;
            return Task.CompletedTask;
        }

    }
}
