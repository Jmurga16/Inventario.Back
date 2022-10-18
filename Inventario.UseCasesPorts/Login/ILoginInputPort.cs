using Inventario.UseCasesDTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.Login
{
    public interface ILoginInputPort
    {
        Task Login(LoginRequest request);
    }
}
