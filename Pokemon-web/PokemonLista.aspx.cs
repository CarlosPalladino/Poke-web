﻿using Dominio1;
using Negocio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemon_web
{
    public partial class PokemonLista : System.Web.UI.Page
    {

        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {

                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("listaPokemons", negocio.filtrarSP());

                dgvPokemons.DataSource = Session["listaPokemons"];
                dgvPokemons.DataBind();
            }

        }


        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();

        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {

            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];

            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }




        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Número")


            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a ");
                ddlCriterio.Items.Add("Menor a");

            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }



        protected void btnBuscar_Click1(object sender, EventArgs e)
        {

            try
            {
                PokemonNegocio negocio = new PokemonNegocio();


                dgvPokemons.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                ddlCriterio.SelectedItem.ToString(),
                txtFiltroAvanzado.Text,
                ddlEstado.SelectedItem.ToString());
                dgvPokemons.DataBind();


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);

            }
        }

        protected void chkAvanzado_CheckedChanged1(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }
    }
}