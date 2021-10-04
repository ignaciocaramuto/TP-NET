<%@ Page Title="Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Blue"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="ID Materia" DataField="IDMateria" />
            <asp:BoundField HeaderText="ID Comision" DataField="IDComision" />
            <asp:BoundField HeaderText="Año calendario" DataField="AnioCalendario" />
            <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID ="idMateriaLabel" runat="server" Text="ID Materia: "></asp:Label>
        <asp:TextBox ID="idMateriaTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdMateria" runat="server" 
            ControlToValidate="idMateriaTextBox" 
            ErrorMessage="ID de materia es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idComisionLabel" runat="server" Text="ID Comision: "></asp:Label>
        <asp:TextBox ID="idComisionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdComision" runat="server" 
            ControlToValidate="idComisionTextBox" 
            ErrorMessage="ID Comision es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="anioCalendarioLabel" runat="server" Text="Año de calendario: "></asp:Label>
        <asp:TextBox ID="anioCalendarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAnioCalendario" runat="server" 
            ControlToValidate="anioCalendarioTextBox" 
            ErrorMessage="Año calendario es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCupo" runat="server" 
            ControlToValidate="cupoTextBox" 
            ErrorMessage="Cupo es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" ValidateRequestMode="Disabled" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
        <br />
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
</asp:Content>
