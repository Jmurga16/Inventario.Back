using Inventario.UseCasesDTOs.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.User.FormUser
{
    public interface IFormUserOutputPort
    {
        Task Handle( GeneralResponse response);
    }
}
