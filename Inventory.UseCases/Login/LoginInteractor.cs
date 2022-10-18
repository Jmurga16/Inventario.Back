using Inventario.ADONet;
using Inventario.Entities.Exceptions;
using Inventario.UseCasesDTOs.Login;
using Inventario.UseCasesPorts.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCases.Login
{
    public class LoginInteractor:ILoginInputPort
    {
        readonly Conexion conexion;
        readonly ILoginOutputPort OutputPort;

        public LoginInteractor(Conexion conexion, ILoginOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        public async Task Login(LoginRequest request)
        {

            IEnumerable<LoginResponse> response;

            try
            {

                List<LoginResponse> lista = new List<LoginResponse>();

                //Opcion 1 : Listar Todo

                using (IDataReader dr = conexion.ejecutarDataReader("USP_MNT_Login", request.sNombreUsuario, request.sContrasenia))
                {
                    while (dr.Read())
                    {
                        LoginResponse entity = new LoginResponse();
                                               
                        entity.Result = Convert.ToInt32(dr["Result"]);
                        entity.nIdRol = Convert.ToInt32(dr["nIdRol"]);

                        lista.Add(entity);

                    }

                    response = lista;

                }

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al ingresar.", ex.Message);
            }

            await OutputPort.Handle(response);
        }


    }
}
