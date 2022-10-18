using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.POCOEntities
{
    public class Historial
    {
        public int nIdHistorial { get; set; }
        public int nIdUsuario { get; set; }
        public int nIdProducto { get; set; }
        public string? sAccion { get; set; }
        public DateTime dFecha { get; set; }
    }
}
