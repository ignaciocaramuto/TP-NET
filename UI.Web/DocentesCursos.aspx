<%@ Page Title="DocentesCursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.Docentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Blue"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="ID Curso" DataField="IDCurso" />
            <asp:BoundField HeaderText="ID Docente" DataField="IDDocente" />
            <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID ="idCursoLabel" runat="server" Text="ID Curso: "></asp:Label>
        <asp:TextBox ID="idCursoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdCurso" runat="server" 
            ControlToValidate="idCursoTextBox" 
            ErrorMessage="ID de curso es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idDocenteLabel" runat="server" Text="ID Docente: "></asp:Label>
        <asp:TextBox ID="idDocenteTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdDocente" runat="server" 
            ControlToValidate="idDocenteTextBox" 
            ErrorMessage="ID de docente es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="cargoLabel" runat="server" Text="Cargo: "></asp:Label>
        <asp:TextBox ID="cargoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCargo" runat="server" 
            ControlToValidate="cargoTextBox" 
            ErrorMessage="Cargo es obligatorio" 
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
