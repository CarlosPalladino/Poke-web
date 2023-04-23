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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            try
            {

                Trainee user = new Trainee();

                TraineNegocio TraineNegocio = new TraineNegocio();

                EmailService EmailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

               user.Id= TraineNegocio.insertarNuevo(user);
                Session.Add("trainee", user);

                EmailService.armarCorreo(user.Email, "Bienvenid@", "hola, testc damos la bienvenida");
                EmailService.enviarEmail();
                Response.Redirect("default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}