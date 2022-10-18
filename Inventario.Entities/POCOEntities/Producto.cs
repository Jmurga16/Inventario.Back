using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.Entities.POCOEntities
{
    public class Producto
    {
        public int nIdProducto { get; set; }
        public string? sNombre { get; set; }
        public string? sDescripcion { get; set; }
        public int nStock { get; set; }
        public bool bEstado { get; set; }

    }
}
