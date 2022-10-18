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

        public async Task GetUserById(int nOpcion, int nIdUsuario)
        {

            IEnumerable<ListUserByIdResponse> response;

            try
            {

                List<ListUserByIdResponse> listaUsers = new List<ListUserByIdResponse>();

                //Opcion 1 : Listar Todo
              
                using (IDataReader dr = conexion.ejecutarDataReader("USP_GET_Usuarios", nOpcion, nIdUsuario))
                {
                    while (dr.Read())
                    {
                        ListUserByIdResponse entity = new ListUserByIdResponse();
                                          
                        entity.sNombres = Convert.ToString(dr["sNombres"]);
                        entity.sApellidos = Convert.ToString(dr["sApellidos"]);
                        entity.nTipoDoc = Convert.ToInt32(dr["nTipoDoc"]);
                        entity.sNumDoc = Convert.ToString(dr["sNumDoc"]);
                        entity.sSexo = Convert.ToString(dr["sSexo"]);
                        entity.nIdRol = Convert.ToInt32(dr["nRol"]);
                        entity.sDireccion = Convert.ToString(dr["sDireccion"]);
                        entity.nTelefono = Convert.ToInt32(dr["nTelefono"]);
                        entity.sContrasenia = Convert.ToString(dr["sContrasenia"]);
                        entity.dFechaNac = Convert.ToString(dr["dFechaNac"]);
                        entity.dFechaNacimiento = Convert.ToDateTime(dr["dFechaNacimiento"]);


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
