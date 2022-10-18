using Inventario.ADONet;
using Inventario.Entities.Exceptions;
using Inventario.UseCasesDTOs.Inventory.ListInventory;
using Inventario.UseCasesPorts.Inventory.ListInventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.UseCases.Inventory.ListInventory
{
    public class ListInventoryInteractor: IListInventoryInputPort
    {
        readonly Conexion conexion;
        readonly IListInventoryOutputPort OutputPort;

        public ListInventoryInteractor(Conexion conexion, IListInventoryOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Obtener Lista de Usuarios
        public async Task GetInventory()
        {

            IEnumerable<ListInventoryResponse> response;

            try
            {

                List<ListInventoryResponse> listaInventorys = new List<ListInventoryResponse>();

                //Opcion 1 : Listar Todo
                var nOpcion = 1;
                var nIdUsuario = 0;

                using (IDataReader dr = conexion.ejecutarDataReader("USP_GET_Productos", nOpcion, nIdUsuario))
                {
                    while (dr.Read())
                    {
                        ListInventoryResponse entity = new ListInventoryResponse();

                        entity.nIdProducto = Convert.ToInt32(dr["nIdProducto"]);
                        entity.sNombre = Convert.ToString(dr["sNombre"]);
                        entity.sDescripcion = Convert.ToString(dr["sDescripcion"]);
                        entity.nStock = Convert.ToInt32(dr["nStock"]);
                        entity.bEstado = Convert.ToBoolean(dr["bEstado"]);

                        listaInventorys.Add(entity);

                    }

                    response = listaInventorys;

                }

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al listar productos.", ex.Message);
            }

            await OutputPort.Handle(response);
        }

        //Obtener Lista de Usuarios por Id
        public async Task GetInventoryById(int nOpcion, int nIdUsuario)
        {

            IEnumerable<ListInventoryResponse> response;

            try
            {

                List<ListInventoryResponse> listaInventorys = new List<ListInventoryResponse>();

                //Opcion 2 : Listar por Identificador

                using (IDataReader dr = conexion.ejecutarDataReader("USP_GET_Productos", nOpcion, nIdUsuario))
                {
                    while (dr.Read())
                    {
                        ListInventoryResponse entity = new ListInventoryResponse();

                        entity.nIdProducto = Convert.ToInt32(dr["nIdProducto"]);
                        entity.sNombre = Convert.ToString(dr["sNombre"]);
                        entity.sDescripcion = Convert.ToString(dr["sDescripcion"]);
                        entity.nStock = Convert.ToInt32(dr["nStock"]);
                        entity.bEstado = Convert.ToBoolean(dr["bEstado"]);

                        listaInventorys.Add(entity);

                    }

                    response = listaInventorys;

                }

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al listar producto.", ex.Message);
            }

            await OutputPort.Handle(response);
        }

    }
}
