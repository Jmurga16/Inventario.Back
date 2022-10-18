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

        //[HttpGet("{id}")]
        //public async Task<IEnumerable<ListUserResponse>> GetUsers(int nIdUsuario)
        //{

        //    await ListUserByIdInputPort.GetUsers();

        //    var Presenter = ListUserByIdOutputPort as ListUserUserByIdPresenter;

        //    return Presenter.Content;
        //}

    }
}
