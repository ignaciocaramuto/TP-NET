﻿<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="ContentUsuarios" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section>
        <h1 style="text-align: center">ABMC de Usuarios</h1>
    </section>
    <section class="content">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <div class="row">
                <div visible="False">
                    <div class="box box-primary" style="margin-left: auto; margin-right: auto; width: 50%; display: block;">
                        <div class="box box-body">
                            <div class="form-group">
                                <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="seleccionarPersonaLabel" runat="server" Text="Seleccionar persona"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListPersonas" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:CheckBox ID="checkBoxHabilitado" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="formPanelActions" runat="server" Visible="False">
                <div class="row">
                    <div align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="cancelarButton_Click" CssClass="btn btn-danger" Width="100px">Cancelar</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="btnAceptar" runat="server" OnClick="aceptarButton_Click" CssClass="btn btn-primary" Width="100px">Aceptar</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </asp:Panel>
    </section>
    <section>
        <asp:Panel ID="gridPanel" runat="server">
        <div class="container">
            <asp:GridView ID="gridView" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="false"
            DataKeyNames="ID" AllowSorting="True" HorizontalAlign="Center" OnRowCommand="gridView_RowCommand" >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div align="center">
                            <asp:LinkButton ID="editarLinkButton" runat="server" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="fa fa-pencil fa-lg"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="eliminarLinkButton" runat="server" CommandName="Borrar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="fa fa-trash-o fa-lg" style="color: red"></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle HorizontalAlign="Center" CssClass="table-primary"/>
            <RowStyle  />
        </asp:GridView>
            <asp:Panel ID="gridActionsPanel" runat="server">
            <div class="d-flex justify-content-end" style="margin-right: 30px">
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn btn-success" Width="100px">Nuevo</asp:LinkButton>
            </div>
        </asp:Panel>
        </div> 
        </asp:Panel>
        
    </section>
</asp:Content>
