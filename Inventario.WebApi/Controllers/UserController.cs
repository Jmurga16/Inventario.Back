using Inventario.UseCasesDTOs.General;
using Inventario.UseCasesDTOs.User.ListUser;
using Inventario.UseCasesPorts.User.FormUser;
using Inventario.UseCasesPorts.User.ListUser;
using Microsoft.AspNetCore.Mvc;
using Presenters.User.FormUser;
using Presenters.User.ListUser;

namespace Inventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        readonly IListUserInputPort ListUserInputPort;
        readonly IListUserOutputPort ListUserOutputPort;

        readonly IFormUserInputPort FormUserInputPort;
        readonly IFormUserOutputPort FormUserOutputPort;

        public UserController
            (IListUserInputPort listUserInputPort, IListUserOutputPort listUserOutputPort,
            IFormUserInputPort formUserInputPort, IFormUserOutputPort formUserOutputPort) =>
            (ListUserInputPort, ListUserOutputPort, FormUserInputPort, FormUserOutputPort) =
            (listUserInputPort, listUserOutputPort, formUserInputPort, formUserOutputPort);


        #region EndPoint: Obtener Todos los Usuarios

        [HttpGet]
        public async Task<IEnumerable<ListUserResponse>> GetUsers()
        {

            await ListUserInputPort.GetUsers();

            var Presenter = ListUserOutputPort as ListUserPresenter;

            return Presenter.Content;
        }
        #endregion


        #region EndPoint: Obtener Un Usuario por Id
        [HttpGet("{nIdUsuario}")]
        public async Task<IEnumerable<ListUserByIdResponse>> GetUsers(int nOpcion, int nIdUsuario)
        {

            await ListUserInputPort.GetUserById(nOpcion, nIdUsuario);

            var Presenter = ListUserOutputPort as ListUserPresenter;

            return Presenter.ContentById;
        }
        #endregion


        #region EndPoint: Insertar | Editar | Eliminar => Usuario
        [HttpPost]
        public async Task<GeneralResponse> PostUser(GeneralRequest request)
        {

            await FormUserInputPort.PostUser(request);

            var Presenter = FormUserOutputPort as FormUserPresenter;

            return Presenter.Content;
        }
        #endregion

    }
}
