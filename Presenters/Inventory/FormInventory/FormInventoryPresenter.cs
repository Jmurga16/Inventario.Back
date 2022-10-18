using Inventario.UseCasesDTOs.General;
using Inventario.UseCasesPorts.Inventory.FormInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Inventory.FormInventory
{
    public class FormInventoryPresenter : IFormInventoryOutputPort, IPresenter<GeneralResponse>
    {
        public GeneralResponse Content { get; private set; }

        public Task Handle(GeneralResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
