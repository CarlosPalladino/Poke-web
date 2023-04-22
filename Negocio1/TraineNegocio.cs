using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio1;

namespace Negocio1
{
    public  class TraineNegocio
    {
        public int insertarNuevo(Trainee nuevo)
        {
				AccesoDatos datos  = new AccesoDatos();	
			try
			{
				datos.setearProcedimiento("insertarNuevo");

				datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);
              return   datos.ejecutarAccionEscala();
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
