using Inventario.UseCasesDTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.Login
{
    public interface ILoginOutputPort
    {
        Task Handle(IEnumerable<LoginResponse> Login);
    }
}
