using Inventario.ADONet;
using Inventario.Entities.Exceptions;
using Inventario.UseCasesDTOs.User.ListUser;
using Inventario.UseCasesPorts.User.ListUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.UseCases.Users.ListUser
{
    public class ListUserInteractor : IListUserInputPort
    {
        readonly Conexion conexion;
        readonly IListUserOutputPort OutputPort;

        public ListUserInteractor(Conexion conexion, IListUserOutputPort outputPort)
        {
            this.conexion = new Conexion();
            OutputPort = outputPort;
        }

        //Obtener Lista de Usuarios
        public async Task GetUsers()
        {

            IEnumerable<ListUserResponse> response;

            try
            {

                List<ListUserResponse> listaUsers = new List<ListUserResponse>();
                
                //Opcion 1 : Listar Todo
                var nOpcion = 1;
                var nIdUsuario = 0;

                using (IDataReader dr = conexion.ejecutarDataReader("USP_GET_Usuarios", nOpcion, nIdUsuario))
                {
                    while (dr.Read())
                    {
                        ListUserResponse entity = new ListUserResponse();

                        entity.nIdUsuario = Convert.ToInt32(dr["nIdUsuario"]);
                        entity.sNombrePersona = Convert.ToString(dr["sNombrePersona"]);
                        entity.sNombreUsuario = Convert.ToString(dr["sNombreUsuario"]);
                        entity.sNombreRol = Convert.ToString(dr["sNombreRol"]);
                        entity.sEstado = Convert.ToString(dr["sEstado"]);
                        
                        listaUsers.Add(entity);

                    }

                    response = listaUsers;

                }

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al listar usuarios.", ex.Message);
            }

            await OutputPort.Handle(response);
        }
    }
}
