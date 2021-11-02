<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<section>
        <h1 style="text-align: center">ABMC de Cursos</h1>
    </section>
    <section class="content">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <div class="row">
                <div visible="False">
                    <div class="box box-primary" style="margin-left: auto; margin-right: auto; width: 50%; display: block;">
                        <div class="box box-body">
                            <div class="form-group">
                                <asp:Label ID="lblEspecialidad" runat="server" Text="Seleccionar especialidad"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlEspecialidades" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" 
                                Display="Dynamic" ErrorMessage="Por favor seleccione una especialidad" />
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblPlan" runat="server" Text="Seleccionar plan"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlPlanes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblMateria" runat="server" Text="Seleccionar materia"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlMaterias" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblComision" runat="server" Text="Seleccionar comisión"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlComisiones" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblAnioCalendario" runat="server" Text="Año calendario"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtAnioCalendario" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAnioCalendario" runat="server" ControlToValidate="txtAnioCalendario" 
                                ErrorMessage="El campo Año calendario es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblCupo" runat="server" Text="Cupo"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtCupo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCupo" runat="server" ControlToValidate="txtCupo" 
                                ErrorMessage="El campo Cupo es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <br />
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
                <asp:BoundField HeaderText="Materia" DataField="DescMateria" />
                <asp:BoundField HeaderText="Comision" DataField="DescComision" />
                <asp:BoundField HeaderText="Año calendario" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
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
                <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn btn-success" Width="100px">Nuevo</asp:LinkButton>
            </div>
        </asp:Panel>
        </div> 
        </asp:Panel>
    </section>

</asp:Content>
