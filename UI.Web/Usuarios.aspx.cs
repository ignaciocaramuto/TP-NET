using System;
using Business.Entities;
using Business.Logic;

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

        private void LoadForm (int id)
        {
            Entity = Logic.GetOne(id);
            checkBoxHabilitado.Checked = Entity.Habilitado;
            txtNombreUsuario.Text = Entity.NombreUsuario;
            //this.personaTextBox.Text = this.Entity.Persona.Apellido + " " + this.Entity.Persona.Nombre;
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Clave = txtClave.Text;
            usuario.Habilitado = checkBoxHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }

        private void DeleteEntity (int id)
        {
            Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            formPanel.Visible = true;
        }

        private void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    break;
                case FormModes.Modificacion:
                    Entity = Logic.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;
                case FormModes.Alta:
                    Entity = new Usuario();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    LoadGrid();
                    break;
                default:
                    break;
            }
            formPanel.Visible = false;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            gridActionsPanel.Visible = false;
            formPanel.Visible = true;
            formPanelActions.Visible = true;
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
                SelectedID = Convert.ToInt32(e.CommandArgument) + 1;

                formPanel.Visible = true;
                formPanelActions.Visible = true;
                seleccionarPersonaLabel.Visible = false;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
            
            if (e.CommandName == "Borrar")
            {
                SelectedID = Convert.ToInt32(e.CommandArgument) + 1;

                formPanel.Visible = true;
                formPanelActions.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }
    }
}