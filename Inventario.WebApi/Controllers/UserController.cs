using Inventario.UseCasesDTOs.User.ListUser;
using Inventario.UseCasesPorts.User.ListUser;
using Microsoft.AspNetCore.Mvc;
using Presenters.User.ListUser;

namespace Inventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        readonly IListUserInputPort ListUserInputPort;
        readonly IListUserOutputPort ListUserOutputPort;


        public UserController(IListUserInputPort listUserInputPort, IListUserOutputPort listUserOutputPort) =>
        (ListUserInputPort, ListUserOutputPort) = (listUserInputPort, listUserOutputPort);


        [HttpGet]
        public async Task<IEnumerable<ListUserResponse>> GetUsers()
        {

            await ListUserInputPort.GetUsers();

            var Presenter = ListUserOutputPort as ListUserPresenter;

            return Presenter.Content;
        }

        [HttpGet("{nIdUsuario}")]
        public async Task<IEnumerable<ListUserByIdResponse>> GetUsers(int nOpcion, int nIdUsuario)
        {

            await ListUserInputPort.GetUserById(nOpcion, nIdUsuario);

            var Presenter = ListUserOutputPort as ListUserPresenter;

            return Presenter.ContentById;
        }

    }
}
