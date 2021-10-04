<%@ Page Title="Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
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
            <asp:BoundField HeaderText="Horas semanales" DataField="HsSemanales" />
            <asp:BoundField HeaderText="Horas totales" DataField="HsTotales" />
            <asp:BoundField HeaderText="ID Plan" DataField="IdPlan" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID ="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" runat="server" 
            ControlToValidate="descripcionTextBox" 
            ErrorMessage="Descripción es obligatoria" 
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas semanales: "></asp:Label>
        <asp:TextBox ID="hsSemanalesTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorHsSemanales" runat="server" 
            ControlToValidate="hsSemanalesTextBox" 
            ErrorMessage="Horas semanales es obligatorio" 
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas totales: "></asp:Label>
        <asp:TextBox ID="hsTotalesTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorHorasTotales" runat="server" 
            ControlToValidate="hsTotalesTextBox" 
            ErrorMessage="Horas totales es obligatorio" 
            ForeColor="Red">
        </asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="idPlanLabel" runat="server" Text="ID Plan: "></asp:Label>
        <asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIdPlan" runat="server" 
            ControlToValidate="idPlanTextBox" 
            ErrorMessage="ID de plan es obligatorio" 
            ForeColor="Red">
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
