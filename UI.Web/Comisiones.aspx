<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section>
        <h1 style="text-align: center">ABMC de Comisiones</h1>
    </section>
    <section class="content">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <div class="row">
                <div visible="False">
                    <div class="box box-primary" style="margin-left: auto; margin-right: auto; width: 50%; display: block;">
                        <div class="box box-body">
                            <div class="form-group">
                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescripcion" runat="server" ControlToValidate="txtDescripcion" 
                                ErrorMessage="El campo Descripción es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblAnioEspecialidad" runat="server" Text="Anio Especialidad"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAnioEspecialidad" runat="server" ControlToValidate="txtAnio" 
                                ErrorMessage="El campo anio especialidad es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />                           
                            <div class="form-group">
                                <asp:Label ID="lblEspecialidad" runat="server" Text="Seleccionar especialidad"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlEspecialidades" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" 
                                Display="Dynamic" ErrorMessage="Por favor selecciona una especialidad" />
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblPlan" runat="server" Text="Seleccionar plan"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlPlanes" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged">
                                </asp:DropDownList>
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
                                    <asp:LinkButton ID="btnCancelar" runat="server" OnClick="cancelarButton_Click" CausesValidation="false" CssClass="btn btn-danger" Width="100px">Cancelar</asp:LinkButton>&nbsp;
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
            DataKeyNames="ID" AllowSorting="True" HorizontalAlign="Center" OnRowCommand="gridView_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:BoundField HeaderText="Anio Especialidad" DataField="AnioEspecialidad" />                
                <asp:BoundField HeaderText="Especialidad" DataField="DescEspecialidad" />
                <asp:BoundField HeaderText="Plan" DataField="DescPlan" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div align="center">
                            <asp:LinkButton ID="editarLinkButton" runat ="server" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="fa fa-pencil fa-lg"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="eliminarLinkButton" OnClientClick="return confirm('¿Estás seguro que deseas eliminar esta comision?');" runat="server" CommandName="Borrar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="fa fa-trash-o fa-lg" style="color: red"></asp:LinkButton>
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