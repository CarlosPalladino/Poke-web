using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio1;
using Negocio1;

namespace Pokemon_web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();

                    List<Elemento> lista = negocio.listar();
                    ddlTipos.DataSource = lista;
                    ddlTipos.DataValueField = "id";
                    ddlTipos.DataTextField = "Descripcion";
                    ddlTipos.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();

                }
                // si estamos modificando se hace . .
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != null && !IsPostBack)
                {

                    PokemonNegocio negocio = new PokemonNegocio();
                    Pokemon seleccionado = (negocio.listar(id))[0];
                    //guardar info en session
                    Session.Add("pokeSeleccionado", seleccionado);

                    //precargar campos 
                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtNumero.Text = seleccionado.Numero.ToString();

                    ddlTipos.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    txtImagenUrl_TextChanged1(sender, e);

                    //acciones
                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";


                }



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipos.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else


                    negocio.agregarSP(nuevo);




                Response.Redirect("PokemonLista.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);

            }
        }



        protected void txtImagenUrl_TextChanged1(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmacionEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(txtId.Text.ToString()));
                    Response.Redirect("PokemonLista.aspx");

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();

                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("PokemonLista.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }


        }
    }
}