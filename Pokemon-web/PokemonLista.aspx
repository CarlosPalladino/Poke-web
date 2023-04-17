<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="Pokemon_web.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="dgvPokemons" runat="server" CssClass="table" AutoGenerateColumns="false"></asp:GridView>
    <columns>
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />

        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
    </columns>
</asp:Content>
