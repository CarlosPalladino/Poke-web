using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio1;


namespace Pokemon_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineNegocio negocio = new TraineNegocio();

            // try
            //   {
            if (Validacion.ValidaTextoVacio(txtEmail)|| Validacion.ValidaTextoVacio(txtPassword))
            {
                Session.Add("error", "Debes completar ambos campos..");
                Response.Redirect("Error.aspx");
            }
            
            trainee.Email = txtEmail.Text;
            trainee.Pass = txtPassword.Text;

            if (negocio.Login(trainee))
            {

                Session.Add("trainee", trainee);
                Response.Redirect("miPerfil.aspx", false);
            }
            else
            {
                // throw new Exception("eRROR lalal");
                Session.Add("error", "user o pass incorrecto");
                Response.Redirect("error.aspx", false);
            }
        }

     

  
    }
}