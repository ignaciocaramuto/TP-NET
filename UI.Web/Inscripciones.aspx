<%@ Page Title="Inscripciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Blue"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="ID Alumno" DataField="IdAlumno" />
            <asp:BoundField HeaderText="ID Curso" DataField="IdCurso" />
            <asp:BoundField HeaderText="Condicion" DataField="Condicion" />
            <asp:BoundField HeaderText="Nota" DataField="Nota" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID ="idAlumnoLabel" runat="server" Text="ID Alumno: "></asp:Label>
        <asp:TextBox ID="idAlumnoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdAlumno" runat="server" 
            ControlToValidate="idAlumnoTextBox" 
            ErrorMessage="ID de alumno es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idCursoLabel" runat="server" Text="ID Curso: "></asp:Label>
        <asp:TextBox ID="idCursoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdCurso" runat="server" 
            ControlToValidate="idCursoTextBox" 
            ErrorMessage="ID de curso es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="condicionLabel" runat="server" Text="Condicion: "></asp:Label>
        <asp:TextBox ID="condicionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCondicion" runat="server" 
            ControlToValidate="condicionTextBox" 
            ErrorMessage="Condición es obligatorio" 
            ForeColor="Red">
            *
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
        <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
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
