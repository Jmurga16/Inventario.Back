using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.POCOEntities
{
    internal class Login
    {
        public int nIdUsuario { get; set; }
        public string? sNombreUsuario { get; set; }
        public string? sContrasenia { get; set; }
    }
}
