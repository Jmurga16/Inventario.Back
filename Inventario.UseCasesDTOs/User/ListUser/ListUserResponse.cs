using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesDTOs.User.ListUser
{
    public class ListUserResponse
    {
        public int nIdUsuario { get; set; }
        public string? sNombrePersona { get; set; }
        public string? sNombreUsuario { get; set; }
        public string? sNombreRol { get; set; }
        public string? sEstado { get; set; }
    }
}
