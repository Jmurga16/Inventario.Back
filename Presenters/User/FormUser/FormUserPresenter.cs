using Inventario.UseCasesDTOs.General;
using Inventario.UseCasesPorts.User.FormUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.User.FormUser
{
    public class FormUserPresenter : IFormUserOutputPort, IPresenter<GeneralResponse>
    {
        public GeneralResponse Content { get; private set; }

        public Task Handle(GeneralResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
