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
    public partial class miPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineNegocio negocio = new TraineNegocio();
                string ruta = Server.MapPath("./imagenes/");

                Trainee user = (Trainee)Session["trainee"];

                txtImage.PostedFile.SaveAs(ruta +"perfil-" + user.Id +".jpg");

                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                negocio.Actualizar(user);

                Image img =(Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/imagenes/" + user.ImagenPerfil;

            }
            catch (Exception ex)
            {
                Session.Add("error",ex.ToString()); 
            }
        }
    }
}