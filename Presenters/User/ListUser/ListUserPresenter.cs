using Inventario.UseCasesDTOs.User.ListUser;
using Inventario.UseCasesPorts.User.ListUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.User.ListUser
{
    public class ListUserPresenter : IListUserOutputPort, IPresenter<IEnumerable<ListUserResponse>>
    {
        public IEnumerable<ListUserResponse> Content { get; private set; } 

        public Task Handle(IEnumerable<ListUserResponse> User)
        {
            Content = User;
            return Task.CompletedTask;
        }
    }
}
