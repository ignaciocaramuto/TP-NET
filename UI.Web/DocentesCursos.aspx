<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.DocentesCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<section>
        <h1 style="text-align: center">ABMC de Docentes a Cursos</h1>
    </section>
    <section class="content">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <div>
                <asp:Label ID="lblDocente" runat="server" Text="Seleccionar docente:"></asp:Label>
                <asp:DropDownList ID="ddlDocentes" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDocente" runat="server" ControlToValidate="ddlDocentes" 
                    Display="Dynamic" ErrorMessage="Por favor seleccione un docente" />
                <asp:Label ID="lblDocenteSeleccionado" runat="server" Text="" Visible="false" CssClass="form-control" > </asp:Label>
                <asp:Label ID="lblCargo" runat="server" Text="Seleccionar cargo:"></asp:Label>
                <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-control">
                    <asp:ListItem Value="Mensaje">--Seleccione Cargo--</asp:ListItem>
                    <asp:ListItem>Titular</asp:ListItem>
                    <asp:ListItem>Auxiliar</asp:ListItem>
                    <asp:ListItem>Ayudante</asp:ListItem>
                </asp:DropDownList>
              </div>
            <asp:Panel ID="formPanelActions" runat="server" Visible="False">
                <div class="row">
                    <div align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" CausesValidation="false" CssClass="btn btn-danger" Width="100px">Cancelar</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary" Width="100px">Aceptar</asp:LinkButton>
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
            DataKeyNames="ID" AllowSorting="True" HorizontalAlign="Center" OnRowCommand="gridView_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Apellido" DataField="ApellidoDocente" />
                <asp:BoundField HeaderText="Nombre" DataField="NombreDocente" />
                <asp:BoundField HeaderText="Cargo" DataField="Cargo" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div align="center">
                            <asp:LinkButton ID="editarLinkButton" runat="server" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="fa fa-pencil fa-lg"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClientClick="return confirm('¿Estás seguro que deseas eliminar este curso?');" CommandName="Borrar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="fa fa-trash-o fa-lg" style="color: red"></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle HorizontalAlign="Center" CssClass="table-primary"/>
            <RowStyle  />
        </asp:GridView>
            <asp:Panel ID="gridActionsPanel" runat="server">
            <div class="d-flex justify-content-end" style="margin-right: 30px">
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click1" CssClass="btn btn-success" Width="100px">Nuevo</asp:LinkButton>
            </div>
        </asp:Panel>
        </div> 
        </asp:Panel>
    </section>
</asp:Content>
