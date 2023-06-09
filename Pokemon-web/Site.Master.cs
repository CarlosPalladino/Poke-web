﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio1;
using Dominio;

namespace Pokemon_web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            imgPerfil.ImageUrl = "https://i.pinimg.com/originals/f1/0f/f7/f10ff70a7155e5ab666bcdd1b45b726d.jpg";

            if (!(Page is Login || Page is Registro || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);

                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgPerfil.ImageUrl = "~/imagenes/" + user.ImagenPerfil;
                }
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}