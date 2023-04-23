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

            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["trainee"]))
                {
                    Trainee user = (Trainee)Session["trainee"];
                    txtEmail.Text = user.Email;
                    txtEmail.ReadOnly = true;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Email;
                    txtFechaNacimiento.Text = user.fechaNacimiento.ToString("yyyy-MM-dd");
                    if(!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgNuevoPerfil.ImageUrl = "~/imagenes/" + user.ImagenPerfil;
                
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineNegocio negocio = new TraineNegocio();
                Trainee user = (Trainee)Session["trainee"];
               
                if(txtImage.PostedFile.FileName != "")
                {
                string ruta = Server.MapPath("./imagenes/");
                txtImage.PostedFile.SaveAs(ruta +"perfil-" + user.Id +".jpg");
                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                }



                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

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