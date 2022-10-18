using Inventario.UseCasesDTOs.Login;
using Inventario.UseCasesPorts.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Login
{
    public class LoginPresenter : ILoginOutputPort, IPresenter<IEnumerable<LoginResponse>>
    {
        public IEnumerable<LoginResponse> Content { get; private set; }

        public Task Handle(IEnumerable<LoginResponse> loginResponses)
        {
            Content = loginResponses;
            return Task.CompletedTask;
        }

    }
}
