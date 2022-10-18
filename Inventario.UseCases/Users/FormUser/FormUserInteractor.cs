using Inventario.ADONet;
using Inventario.Entities.Exceptions;
using Inventario.UseCasesDTOs.General;
using Inventario.UseCasesPorts.User.FormUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCases.Users.FormUser
{
    public class FormUserInteractor : IFormUserInputPort
    {
        readonly Conexion conexion;
        readonly IFormUserOutputPort OutputPort;

        public FormUserInteractor(Conexion conexion, IFormUserOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Obtener Forma de Usuarios
        public async Task PostUser(GeneralRequest request)
        {

            string[] listaRes;
            string sResultado = string.Empty;

            GeneralResponse response;

            try
            {
                if (request.pParametro is not null)
                {
                    sResultado = Convert.ToString(conexion.EjecutarEscalar("USP_MNT_Usuarios", request.nOpcion, request.pParametro));
                    
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
