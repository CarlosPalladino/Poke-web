using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Negocio1
{
    public static class Validacion
    {
        public static bool ValidaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return false;
                else
                    return true;
            }



            return false;
        }


    }
}