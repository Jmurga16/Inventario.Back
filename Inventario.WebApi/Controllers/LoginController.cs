using Inventario.UseCasesDTOs.Login;
using Inventario.UseCasesPorts.Login;
using Microsoft.AspNetCore.Mvc;
using Presenters.Login;

namespace Inventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        readonly ILoginInputPort LoginInputPort;
        readonly ILoginOutputPort LoginOutputPort;


        public LoginController
            (ILoginInputPort loginInputPort, ILoginOutputPort loginOutputPort) =>
            (LoginInputPort, LoginOutputPort) = (loginInputPort, loginOutputPort);


        #region EndPoint: Insertar | Editar | Eliminar => Usuario
        [HttpPost]
        public async Task<IEnumerable<LoginResponse>> Login(LoginRequest request)
        {

            await LoginInputPort.Login(request);

            var Presenter = LoginOutputPort as LoginPresenter;

            return Presenter.Content;
        }
        #endregion
    }
}
