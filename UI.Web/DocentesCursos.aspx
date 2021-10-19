﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="gridPanel" runat="server">
        <h2>Docentes:</h2><br />
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gridView_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ApellidoDocente" HeaderText="Apellido" />
                <asp:BoundField DataField="NombreDocente" HeaderText="Nombre" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
            <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
        </asp:GridView>
            </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="lbEditar" runat="server" CausesValidation="False" 
                onclick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" CausesValidation="False" 
                onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" CausesValidation="False" 
                onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
                </asp:Panel>
            <asp:Panel ID="formPanel" Visible="False" runat="server">
            <br />
            <h4>Seleccionar Docente:</h4>
               <asp:GridView ID="GridViewDocentes" runat="server" AutoGenerateColumns="False" 
            onselectedindexchanged="gridViewDocentes_SelectedIndexChanged" DataKeyNames="ID">
            <Columns>
               
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
               
                <asp:BoundField DataField="EMail" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
               
                <asp:CommandField ShowSelectButton="True" />
               
            </Columns>
            <HeaderStyle BackColor="#CF7500" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F4F4F4" BorderColor="Black" />
            <SelectedRowStyle BackColor="#F0A500" ForeColor="White" />
        </asp:GridView>
        <br />
                <asp:Label ID="lblCargo" runat="server" Text="Seleccionar cargo:"></asp:Label>
                <asp:DropDownList ID="ddlCargo" runat="server" Height="22px" Width="150px">
                    <asp:ListItem Value="Mensaje">--Seleccione Cargo--</asp:ListItem>
                    <asp:ListItem>Titular</asp:ListItem>
                    <asp:ListItem>Auxiliar</asp:ListItem>
                    <asp:ListItem>Ayudante</asp:ListItem>
                </asp:DropDownList>
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbAceptar" runat="server" onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbCancelar" runat="server" CausesValidation="False" 
                        onclick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" 
                        ForeColor="#FF3300" />
                </asp:Panel>
            </asp:Panel>
</asp:Content>
