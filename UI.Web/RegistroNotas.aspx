<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


<section>
        <h1 style="text-align: center">Registro de notas</h1>
</section>
<section>
    <asp:Label ID="lblCursos" runat="server" Text="Mis cursos" CssClass="form-control"></asp:Label>
    <asp:GridView ID="gridViewCursos" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" AllowSorting="True" HorizontalAlign="Center" OnRowCommand="gridViewCursos_RowCommand">
        <Columns>
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año" />
                <asp:BoundField DataField="DescComision" HeaderText="Comision" />
                <asp:BoundField DataField="DescMateria" HeaderText="Materia" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div align="center">
                            <asp:LinkButton ID="seleccionarLinkButton" runat="server" CommandName="Seleccionar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Width="100px" CssClass="btn btn-primary">Seleccionar</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="lblAlumnos" runat="server" Text="Alumnos inscriptos al curso" CssClass="form-control" Visible="false"></asp:Label>
    <asp:GridView ID="gridViewAlumnos" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" AllowSorting="True" HorizontalAlign="Center" OnRowCommand="gridViewAlumnos_RowCommand">
        <Columns>
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div align="center">
                            <asp:LinkButton ID="borrarLinkButton" runat="server" CommandName="Borrar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Width="80px" CssClass="btn btn-primary" style="background-color: maroon">Borrar</asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="modificarLinkButton" runat="server" CommandName="Modificar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Width="80px" CssClass="btn btn-primary">Modificar</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="btnVolver" runat="server" CssClass="btn btn-primary" style="background-color:mediumseagreen"  Visible="false" Align="Center" Width="80px" OnClick="btnVolver_Click">Volver</asp:LinkButton>
</section>
    <section class="content">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <div class="row">
                <div visible="False">
                    <div class="box box-primary" style="margin-left: auto; margin-right: auto; width: 50%; display: block;">
                        <div class="box box-body">
                            <div class="form-group">
                                <asp:Label ID="lblNota" runat="server" Text="Nota" CssClass="form-control"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlNotas" runat="server" CssClass="form-control" CausesValidation="true">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNota" runat="server" ControlToValidate="ddlNotas" Display="Dynamic" ErrorMessage="Por favor asigne una nota" ForeColor="#FF3300"/>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblCondicion" runat="server" Text="Nota"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlCondiciones" runat="server" CssClass="form-control" CausesValidation="true">
                                    <asp:ListItem>Aprobado</asp:ListItem>
                                    <asp:ListItem>Libre</asp:ListItem>
                                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCondicion" runat="server" ControlToValidate="ddlCondiciones" ErrorMessage="Por favor asigne una condición" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
                                    <asp:LinkButton ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary" Width="100px">Aceptar</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
        </asp:Panel>
    </section>

</asp:Content>