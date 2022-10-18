using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesDTOs.User.ListUser
{
    public class ListUserByIdResponse
    {
        public string? sNombres { get; set; }
        public string? sApellidos { get; set; }
        public int nTipoDoc { get; set; }
        public string? sNumDoc { get; set; }
        public string? sSexo { get; set; }
        public int nIdRol { get; set; }
        public string? sDireccion { get; set; }
        public int nTelefono { get; set; }
        public string? sContrasenia { get; set; }
        public DateTime dFechaNacimiento { get; set; }
        public string? dFechaNac { get; set; }
    }
}
