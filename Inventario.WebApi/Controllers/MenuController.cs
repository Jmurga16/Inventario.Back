using Inventario.UseCasesDTOs.Menu.ListMenu;
using Inventario.UseCasesPorts.Menu.ListMenu;
using Microsoft.AspNetCore.Mvc;
using Presenters.Menu.ListMenu;


namespace Inventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {

        readonly IListMenuInputPort ListMenuInputPort;
        readonly IListMenuOutputPort ListMenuOutputPort;


        public MenuController(IListMenuInputPort listMenuInputPort, IListMenuOutputPort listMenuOutputPort) =>
        (ListMenuInputPort, ListMenuOutputPort) = (listMenuInputPort, listMenuOutputPort);


        [HttpGet]
        public async Task<IEnumerable<ListMenuResponse>> GetMenus()
        {

            await ListMenuInputPort.GetMenus();

            var Presenter = ListMenuOutputPort as ListMenuPresenter;

            return Presenter.Content;
        }
    }
}
