<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="miPerfil.aspx.cs" Inherits="Pokemon_web.miPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script>
        function validar() {
            const txtApellido = document.GetElementById("txtApellido");
            if (txtApellido.value == "") {
                alert("Tenes que cargar un apellido")
                return false
            }
            return true;
        }
    </script>
    <h1>Llegaste al perfil </h1>

    
    <div class="row">
        <div class="col-4">
       
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="el nombre es requerido " ControlToValidate="txtNombre" runat="server" />
                
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="txtApellido" CssClass="form-control" />
               // validación comun
                <asp:RangeValidator ErrorMessage="fuera de rango" MinimumValue="2" MaximumValue="20" Type="Integer" ControlToValidate="txtApellido" runat="server" />       
                <asp:RegularExpressionValidator ErrorMessage="Solo numeros"  ValidationExpression="^[0-9]+$" ControlToValidate="txtApellido" runat="server" />

            </div>
            <div class="mb-3">
                <label for="ddlTipos" class="form-label">Fecha de nacimiento</label>
                <asp:TextBox ID="txtFechaNacimiento"    TextMode="Date"  CssClass="form-control" runat="server"/>
            </div>
       
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar"  OnClientClick="return validar()" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="WebForm1.aspx">Cancelar</a>
            </div>

        </div>
        <div class="col-6">

       
            <asp:UpdatePanel ID="UpdatePannel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Url Imagen</label>
                            <input type="file" id="txtImage"         runat="server" class="form-control" />
                    </div>
                    <asp:Image ImageUrl="https://comunidades.cepal.org/ilpes/sites/default/files/users/pictures/default_0.png"
                        runat="server" ID="imgNuevoPerfil"     Width="60%" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </div>
</asp:Content>
