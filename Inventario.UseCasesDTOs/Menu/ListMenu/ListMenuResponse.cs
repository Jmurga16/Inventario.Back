using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCasesDTOs.Menu.ListMenu
{
    public class ListMenuResponse
    {
        public int IdMenu { get; set; }
        public string? Name { get; set; }
        public string? Route { get; set; }
        public string? Icon { get; set; }
        public int IdParent { get; set; }
        public int Level { get; set; }
        public bool Status { get; set; }
    }
}
