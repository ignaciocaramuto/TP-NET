<%@ Page Title="Planes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Blue"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Id especialidad" DataField="IdEspecialidad" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID ="Descripcion" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" runat="server" 
            ControlToValidate="descripcionTextBox" 
            ErrorMessage="Descripcion es obligatoria" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idEspecialidadLabel" runat="server" Text="ID Especialidad: "></asp:Label>
        <asp:TextBox ID="idEspecialidadTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdEspecialidad" runat="server" 
            ControlToValidate="idEspecialidadTextBox" 
            ErrorMessage="ID Especialidad es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
        <br />
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
</asp:Content>
