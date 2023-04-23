using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio1;

namespace Negocio1
{
    public class TraineNegocio
    {
        public void Actualizar(Trainee user)
        {

                AccesoDatos datos= new AccesoDatos();
            try
            {

            
                datos.setearConsulta("Update Users set ImagenPerfil = @imagen  where Id = @id");
                datos.setearParametro("@imagen", user.ImagenPerfil);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           finally {
                datos.cerrarLectura();
            }
          
        }

        public int insertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");

                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
                return datos.ejecutarAccionEscala();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarLectura();
            }



        }

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id, email,pass, admin,imagenPerfil from USERS where email  = @email And pass = @pass");

                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@Pass", trainee.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    if(!(datos.Lector["imagenPerfil"] is DBNull))
                    trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarLectura();
            }
        }

    }
}
