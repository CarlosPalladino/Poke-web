<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="Pokemon_web.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Pokemons</h1>

    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" OnTextChanged="filtro_TextChanged" CssClass="form-control"></asp:TextBox>

            </div>
        </div>
    </div>


    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox ID="chkAvanzado" runat="server"
                AutoPostBack="true"  Text="Filtro Avanzado" 
                  OnCheckedChanged="chkAvanzado_CheckedChanged1" />
        </div>
    </div>

    <%if (FiltroAvanzado)
        { %>
    <div class=" row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" runat="server" />
                <asp:DropDownList css="form-control" AutoPostBack="true" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged"
                    runat="server">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Tipo" />
                    <asp:ListItem Text="Número" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                    <asp:Label Text="Criterio" runat="server" />
                <asp:DropDownList ID="ddlCriterio" css="form-control" runat="server">
                </asp:DropDownList>

            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                    <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox ID="txtFiltroAvanzado" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlEstado" css="form-control" runat="server">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>


            </div>
        </div>


        <div class="col-3">
            <div class="mb-3">

                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary"      OnClick="btnBuscar_Click1" Text="Buscar" />


            </div>
        </div>

        <%} %>
    </div>

    <asp:GridView ID="dgvPokemons" runat="server" CssClass="table" DataKeyNames="Id"
        AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging"
        AllowPaging="true" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Nombre" DataField="Numero" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Escribi algo.." />

        </Columns>
    </asp:GridView>
    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
