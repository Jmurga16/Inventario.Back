using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesDTOs.Login
{
    public class LoginRequest
    {
        public string sNombreUsuario { get; set; }
        public string sContrasenia { get; set; }
    }
}
