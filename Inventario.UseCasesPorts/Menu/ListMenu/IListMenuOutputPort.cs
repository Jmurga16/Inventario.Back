using Inventario.UseCasesDTOs.Menu.ListMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.Menu.ListMenu
{
    public interface IListMenuOutputPort
    {
        Task Handle(IEnumerable<ListMenuResponse> Menu);

    }
}
