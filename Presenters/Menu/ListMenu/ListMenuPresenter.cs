using Inventario.UseCasesDTOs.Menu.ListMenu;
using Inventario.UseCasesPorts.Menu.ListMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Menu.ListMenu
{
    public class ListMenuPresenter : IListMenuOutputPort, IPresenter<IEnumerable<ListMenuResponse>>
    {
        public IEnumerable<ListMenuResponse> Content { get; private set; }

        public Task Handle(IEnumerable<ListMenuResponse> Menu)
        {
            Content = Menu;
            return Task.CompletedTask;
        }
    }
}
