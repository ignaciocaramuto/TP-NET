﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <h2>Comisiones:</h2><br />
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"  
            onselectedindexchanged="gridView_SelectedIndexChanged" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año Especialidad" />
                <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
                <asp:BoundField DataField="DescEspecialidad" HeaderText="Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" BorderColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" BorderColor="Black" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="lbEditar" runat="server" onclick="editarLinkButton_Click" 
                CausesValidation="False">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" 
                onclick="eliminarLinkButton_Click" CausesValidation="False">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" onclick="nuevoLinkButton_Click" 
                CausesValidation="False">Nuevo</asp:LinkButton>
            <br />
            </asp:Panel>
            <asp:Panel ID="formPanel" Visible="false" runat="server">
                <asp:Label ID="lblDescripcion" runat="server" 
                    Text="Descripción de la Comision: "></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtDescripcion" 
                    ErrorMessage="El campo Descripción es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblAnioEspecialidad" runat="server" 
                    Text="Año de la Especialidad: "></asp:Label>
                <asp:TextBox ID="txtAnio" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtAnio" ErrorMessage="El campo Año es obligatorio" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
                <asp:DropDownList ID="ddlEspecialidades" runat="server" Height="16px" 
                    onselectedindexchanged="ddlEspecialidades_SelectedIndexChanged" 
                    Width="150px" AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="ddlEspecialidades" 
                    ErrorMessage="El campo Especialidad es obligatorio" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblPlan" runat="server" Text="Plan:    "></asp:Label>
                <asp:DropDownList ID="ddlPlanes" runat="server" Height="16px" Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="ddlPlanes" ErrorMessage=" Plan es obligatorio" 
                    ForeColor="#FF3300">*  </asp:RequiredFieldValidator>
                    <br />
                <asp:Panel ID="formActionsPanel" runat="server">
                    <asp:LinkButton ID="lbAceptar" runat="server" onclick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
                    <asp:LinkButton ID="lbCancelar" runat="server" 
                        onclick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ForeColor="#FF3300" />
                </asp:Panel>
            </asp:Panel>
        
    </asp:Panel>
</asp:Content>