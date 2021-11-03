<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <section>
        <h1 style="text-align: center">ABMC de Personas</h1>
        <section class="content">
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <div class="row">
                <div visible="False">
                    <div class="box box-primary" style="margin-left: auto; margin-right: auto; width: 50%; display: block;">
                        <div class="box box-body">
                            <div class="form-group">
                                <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass ="form-control"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ControlToValidate="txtNombre" 
                                ErrorMessage="El campo Nombre es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass ="form-control"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApellido" runat="server" ControlToValidate="txtApellido" 
                                ErrorMessage="El campo Apellido es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <div class="form-group">
                                <asp:Label ID="lblDireccion" runat="server" Text="Direccion" CssClass ="form-control"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldDireccion" runat="server" ControlToValidate="txtDireccion" 
                                ErrorMessage="El campo Direccion es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass ="form-control"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldEmail" runat="server" ControlToValidate="txtEmail" 
                                ErrorMessage="El campo Email es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />

                            <div class="form-group">
                                <asp:Label ID="lblTelefono" runat="server" Text="Telefono" CssClass ="form-control"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldTelefono" runat="server" ControlToValidate="txtTelefono" 
                                ErrorMessage="El campo Telefono es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />

                            <div class="form-group">
                                &nbsp;
                                <asp:Label ID="lblFechaNac" runat="server" Text="Fecha nacimiento" CssClass ="form-control"></asp:Label>
                            </div>
                             <div class="form-group">
                                 <div class="form-group">
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:Calendar ID="calendario" runat="server" Align="Center" CssClass="form-control" OnSelectionChanged="calendario_SelectionChanged" Visible="false" Width="266px" SelectedDate="11/03/2021 10:11:11"></asp:Calendar>
                                     &nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;<asp:LinkButton ID="btnCalendario" runat="server" align="center" CausesValidation="False" CssClass="btn btn-success" OnClick="btnCalendario_Click1" Width="100px">Calendario</asp:LinkButton>
                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;
                                     <asp:TextBox ID="txtFechaNac" runat="server"  Align="Center" AutoPostBack="True" CssClass="form-control" OnTextChanged="txtFechaNac_TextChanged" Visible="false"></asp:TextBox>
                                     <br />
                                     <br />
                                     <div class="form-group">
                                         <asp:Label ID="lblLegajo" runat="server" CssClass="form-control" Text="Legajo"></asp:Label>
                                     </div>
                                     <div class="form-group">
                                         <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control"></asp:TextBox>
                                     </div>
                                     <asp:RequiredFieldValidator ID="RequiredFieldLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="El campo legajo es obligatorio" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                     <br />
                                     <div class="form-group">
                                         <asp:Label ID="lblTipoPersona" runat="server" CssClass="form-control" Text="Tipo Persona"></asp:Label>
                                     </div>
                                     <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="form-control">
                                         <asp:ListItem Value="Mensaje">--Seleccione TipoPersona--</asp:ListItem>
                                         <asp:ListItem>Alumno</asp:ListItem>
                                         <asp:ListItem>Docente</asp:ListItem>
                                         <asp:ListItem Value="No docente">No Docente</asp:ListItem>
                                     </asp:DropDownList>
                                     <br />
                                     <div class="form-group">
                                         <asp:Label ID="lblEspecialidad" runat="server" CssClass="form-control" Text="Seleccionar especialidad"></asp:Label>
                                     </div>
                                     <div class="form-group">
                                         <asp:DropDownList ID="ddlEspecialidades" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged">
                                         </asp:DropDownList>
                                     </div>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" Display="Dynamic" ErrorMessage="Por favor selecciona una especialidad" />
                                     <br />
                                     <div class="form-group">
                                         <asp:Label ID="lblPlan" runat="server" CssClass="form-control" Text="Seleccionar plan"></asp:Label>
                                     </div>
                                     <div class="form-group">
                                         <asp:DropDownList ID="ddlPlanes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged">
                                         </asp:DropDownList>
                                     </div>
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
    <section>
        <asp:Panel ID="gridPanel" runat="server">
        <div class="container">
            <asp:GridView ID="gridView" CssClass="table table-bordered table-hover table-responsive" runat="server" AutoGenerateColumns="false"
            DataKeyNames="ID" AllowSorting="True" HorizontalAlign="Center" OnRowCommand="gridView_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />                
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="FechaNacimiento" DataField="FechaNacimiento" />
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Tipo" DataField="DescTipoPersona" />
                <asp:BoundField HeaderText="Plan" DataField="DescPlan" />
                <asp:BoundField HeaderText="Especialidad" DataField="DescEspecialidad" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div align="center">
                            <asp:LinkButton ID="editarLinkButton" runat ="server" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="fa fa-pencil fa-lg"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="eliminarLinkButton" OnClientClick="return confirm('¿Estás seguro que deseas eliminar esta persona?');" runat="server" CommandName="Borrar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CssClass="fa fa-trash-o fa-lg" style="color: red"></asp:LinkButton>
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
    <section>     
    </asp:Panel>
</asp:Content>
