using Inventario.ADONet;
using Inventario.Entities.Exceptions;
using Inventario.UseCasesDTOs.General;
using Inventario.UseCasesPorts.Inventory.FormInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.UseCases.Inventory.FormInventory
{
    public class FormInventoryInteractor : IFormInventoryInputPort
    {
        readonly Conexion conexion;
        readonly IFormInventoryOutputPort OutputPort;

        public FormInventoryInteractor(Conexion conexion, IFormInventoryOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Obtener Forma de Usuarios
        public async Task PostInventory(GeneralRequest request)
        {

            string[] listaRes;
            string sResultado = string.Empty;

            GeneralResponse response;

            try
            {
                if (request.pParametro is not null)
                {
                    sResultado = Convert.ToString(conexion.EjecutarEscalar("USP_MNT_Productos", request.nOpcion, request.pParametro));

                }

                listaRes = sResultado.Split('|');

                response = new GeneralResponse { cod = listaRes[0], mensaje = listaRes[1] };
                response.cod = listaRes[0];

            }


            catch (Exception ex)
            {
                throw new GeneralException("Error al hacer mantenimiento a usuarios.", ex.Message);
            }

            await OutputPort.Handle(response);
        }

    }
}
