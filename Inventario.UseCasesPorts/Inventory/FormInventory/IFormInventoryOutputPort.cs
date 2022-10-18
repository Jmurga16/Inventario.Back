using Inventario.UseCasesDTOs.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.Inventory.FormInventory
{
    public interface IFormInventoryOutputPort
    {
        Task Handle(GeneralResponse response);
    }
}
