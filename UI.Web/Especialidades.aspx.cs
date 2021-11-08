using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Especialidades : Modes
    {
       protected void Page_Load(object sender, EventArgs e)
       {
            if ((string)Session["Privilegio"] != "Admin")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            else
            {
                if (!IsPostBack) LoadGrid();
            }
       }

        EspecialidadLogic _logic;

        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new EspecialidadLogic();
                return _logic;
            }
        }

        Especialidad _Entity;

        private Especialidad Entity
        {
            get
            {
                if (_Entity != null)
                    return _Entity;
                else
                    return null;
            }
            set
            {
                _Entity = value;
            }
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

        private void EnableForm(bool enable)
        {
            lblDescripcion.Visible = enable;
        }

        private void ClearForm()
        {
            txtDescripcion.Text = string.Empty;
        }

        private void DeleteEntity(int id)
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

        private void LoadForm(int id)
        {
            try
            {
                Entity = Logic.GetOne(id);
                txtDescripcion.Text = Entity.Descripcion;
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(Especialidad espec)
        {
            espec.Descripcion = txtDescripcion.Text;
        }

        private void SaveEntity(Especialidad espec)
        {
            try
            {
                Logic.Save(espec);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            gridActionsPanel.Visible = false;
            formPanel.Visible = true;
            formPanelActions.Visible = true;
            txtDescripcion.ReadOnly = false;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        Entity = Logic.GetOne(this.SelectedID);
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                    }
                    break;
                case FormModes.Alta:
                    Entity = new Especialidad();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    gridPanel.Visible = true;
                    break;
                case FormModes.Baja:
                    DeleteEntity(SelectedID);                
                    break;
            }
            ClearForm();
            ClearSession();
            LoadGrid();
            gridActionsPanel.Visible = true;
            formPanel.Visible = false;
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
                txtDescripcion.ReadOnly = false;
                formPanelActions.Visible = true;
                LoadForm(SelectedID);
                FormMode = FormModes.Modificacion;
            }

            if (e.CommandName == "Borrar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedID = (int)gridView.DataKeys[rowIndex]["ID"];

                formPanel.Visible = true;
                txtDescripcion.ReadOnly = true;
                formPanelActions.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        
    }
    
}