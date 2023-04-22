<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Pokemon_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class=" row">
        <div class="col-4">
            <h1>Crea tu perfil </h1>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
                <div class="mb-3">
                <label class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnRegistro" CssClass="btn btn-primary" runat="server"  OnClick="btnRegistro_Click" Text="Registrate" />
    </div>




</asp:Content>
