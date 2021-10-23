using System;
using System.Collections.Generic;
using Business.Entities;
using Business.Logic;
using System.Linq;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Usuarios : Modes
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadGrid();

        }

        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        PersonaLogic logic;
        public PersonaLogic LogicPersona
        {
            get
            {
                if (logic == null)
                    logic = new PersonaLogic();
                return logic;
            }
        }

        private Usuario Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                    return (int)ViewState["SelectedID"];
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        private void LoadForm ()
        {
            try
            {
                Entity = Logic.GetOne(SelectedID);
                dropDownListPersonasLoad();
                DropDownListPersonas.SelectedValue = Entity.Persona.ID.ToString();
                checkBoxHabilitado.Checked = Entity.Habilitado;
                txtNombreUsuario.Text = Entity.NombreUsuario;
                txtClave.Text = Entity.Clave;
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
            
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Clave = txtClave.Text;
            usuario.Persona.ID = Convert.ToInt32(DropDownListPersonas.SelectedValue);
            usuario.Habilitado = checkBoxHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            try
            {
                Logic.Save(usuario);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void DeleteEntity (int id)
        {
            try
            {
                Logic.Delete(id);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void EnableForm(bool enable)
        {
            formPanel.Visible = enable;
        }

        private void LoadGrid()
        {
            try
            {
                gridView.DataSource = Logic.GetAll();
                gridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
                case FormModes.Modificacion:
                    Entity = Logic.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Usuario();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    gridPanel.Visible = true;
                    break;
                default:
                    break;
            }
            ClearSession();
            LoadGrid();
            formPanel.Visible = false;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            gridActionsPanel.Visible = false;
            formPanel.Visible = true;
            formPanelActions.Visible = true;
            txtNombreUsuario.ReadOnly = false;
            txtClave.ReadOnly = false;
            checkBoxHabilitado.Enabled = true;
            DropDownListPersonas.Enabled = true;
            dropDownListPersonasLoad();
            FormMode = FormModes.Alta;      
            ClearForm();
            EnableForm(true);
        }

        private void ClearForm()
        {
            txtNombreUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            checkBoxHabilitado.Checked = false;
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            formPanel.Visible = false;
            formPanelActions.Visible = false;
            gridPanel.Visible = true;
            gridActionsPanel.Visible = true;
        }

        protected void gridView_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            //Valida si el nombre del comando de boton es editar o borrar
            if (e.CommandName == "Editar")
            {
                //Determina el index de la fila de donde el boton fue clickeado
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                //Obtiene el valor de la primary key de la fila que fue seleccionada
                SelectedID = (int)gridView.DataKeys[rowIndex]["ID"];

                formPanel.Visible = true;
                txtNombreUsuario.ReadOnly = false;
                txtClave.ReadOnly = false;
                DropDownListPersonas.Enabled = true;
                checkBoxHabilitado.Enabled = true;
                formPanelActions.Visible = true;                
                LoadForm();
                FormMode = FormModes.Modificacion;
            }
            
            if (e.CommandName == "Borrar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedID = (int)gridView.DataKeys[rowIndex]["ID"];

                formPanel.Visible = true;
                txtNombreUsuario.ReadOnly = true;
                txtClave.ReadOnly = true;
                DropDownListPersonas.Enabled = false;
                checkBoxHabilitado.Enabled = false;
                formPanelActions.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(true);
                LoadForm();
            }
        }

        private void dropDownListPersonasLoad()
        {
            try
            {
                List<Persona> personas = LogicPersona.GetAll();

                //usamos linq para establecer los items del dropdown como nombre + apellido
                var datasource = from p in personas 
                                 select new
                                 {
                                     p.ID,
                                     p.Apellido,
                                     p.Nombre,
                                     DisplayField = String.Format("{0} {1}", p.Apellido, p.Nombre)
                                 };

                DropDownListPersonas.DataSource = datasource;
                DropDownListPersonas.DataValueField = "ID";
                DropDownListPersonas.DataTextField = "DisplayField";
                DropDownListPersonas.DataBind();
            } 
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }

        }

        protected void DropDownListPersonas_DataBound(object sender, EventArgs e)
        {
            //Establece como item por defecto el string "selecciona una persona"
            DropDownListPersonas.Items.Insert(0, new ListItem("--- Selecciona una persona ---", String.Empty));
        }
    }
}