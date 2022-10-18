using Inventario.UseCasesDTOs.User.ListUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesPorts.User.ListUser
{
    public interface IListUserOutputPort
    {
        Task Handle(IEnumerable<ListUserResponse> User);
        //Task Handle(IEnumerable<ListUserByIdResponse> Menu);
    }
}
