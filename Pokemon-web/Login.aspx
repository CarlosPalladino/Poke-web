<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pokemon_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login pa</h1>

    <div class=" row">
        <div class="col-4">
            <h1>Login </h1>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" />

            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>

                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>
        </div>
        <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" OnClick="btnLogin_Click" Text="Registrate" />
    </div>
</asp:Content>
