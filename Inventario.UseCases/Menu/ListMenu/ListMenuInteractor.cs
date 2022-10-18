using Inventario.ADONet;
using Inventario.Entities.Exceptions;
using Inventario.UseCasesDTOs.Menu.ListMenu;
using Inventario.UseCasesPorts.Menu.ListMenu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCases.Menu.ListMenu
{
    public class ListMenuInteractor : IListMenuInputPort
    {

        readonly Conexion oCon;
        readonly IListMenuOutputPort OutputPort;

        public ListMenuInteractor(Conexion oCon, IListMenuOutputPort outputPort)
        {
            this.oCon = new Conexion();
            OutputPort = outputPort;
        }

        //Obtener Lista de Menú
        public async Task GetMenus()
        {

            IEnumerable<ListMenuResponse> response;

            try
            {

                List<ListMenuResponse> listaMenus = new List<ListMenuResponse>();
                var nOpcion = 1;

                using (IDataReader dr = oCon.ejecutarDataReader("USP_MNT_Menu", nOpcion))
                {
                    while (dr.Read())
                    {
                        ListMenuResponse entity = new ListMenuResponse();

                        entity.IdMenu = Convert.ToInt32((dr["IdMenu"]));
                        entity.Name = Convert.ToString(dr["Name"]);
                        entity.Route = Convert.ToString(dr["Route"]);
                        entity.Icon = Convert.ToString(dr["Icon"]);
                        entity.IdParent = Convert.ToInt32(dr["IdParent"]);
                        entity.Level = Convert.ToInt32(dr["Level"]);
                        entity.Status = Convert.ToBoolean(dr["Status"]);


                        listaMenus.Add(entity);

                    }

                    response = listaMenus;

                }

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al listar menú.", ex.Message);
            }

            await OutputPort.Handle(response);
        }
    }
}
