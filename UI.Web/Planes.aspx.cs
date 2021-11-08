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
    public partial class Planes : Modes
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

        PlanLogic _logic;

        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new PlanLogic();
                return _logic;
            }
        }

        EspecialidadLogic logic;
        public EspecialidadLogic LogicEspecialidad
        {
            get
            {
                if (logic == null)
                    logic = new EspecialidadLogic();
                return logic;
            }
        }

        Plan _Entity;

        private Plan Entity
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

        private void ClearSession()
        {
            Session["SelectedID"] = null;
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
            formPanel.Visible = enable;
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
                dropDownListEspecialidadesLoad();
                DropDownListEspecialidades.SelectedValue = Entity.Especialidad.ID.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = txtDescripcion.Text;
            plan.Especialidad.ID = Convert.ToInt32(DropDownListEspecialidades.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            try
            {
                Logic.Save(plan);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            gridPanel.Visible = false;
            gridActionsPanel.Visible = false;
            formPanel.Visible = true;
            formPanelActions.Visible = true;
            txtDescripcion.ReadOnly = false;
            dropDownListEspecialidadesLoad();
            FormMode = FormModes.Alta;
            ClearForm();
            DropDownListEspecialidades.Enabled = true;
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
                    Entity = new Plan();
                    LoadEntity(Entity);
                    if (!Logic.ExistePlan(Entity.Descripcion, Entity.Especialidad.ID))
                    {
                        gridPanel.Visible = true;
                        SaveEntity(Entity);
                    }
                    else
                        Response.Write("<script>window.alert('El Plan ya existe.');</script>");
                    
                    break;
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
            }
            ClearForm();
            ClearSession();
            LoadGrid();
            formPanel.Visible = false;
            gridActionsPanel.Visible = true;
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
                DropDownListEspecialidades.Enabled = true;
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
                DropDownListEspecialidades.Enabled = false;
                EnableForm(true);
                FormMode = FormModes.Baja;
                LoadForm(SelectedID);
            }
        }

        private void dropDownListEspecialidadesLoad()
        {
            try
            {
                List<Especialidad> especialidades = LogicEspecialidad.GetAll();

                DropDownListEspecialidades.DataSource = especialidades;
                DropDownListEspecialidades.DataValueField = "ID";
                DropDownListEspecialidades.DataTextField = "Descripcion";
                DropDownListEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        protected void DropDownListPersonas_DataBound(object sender, EventArgs e)
        {
            //Establece como item por defecto el string "selecciona una persona"
            DropDownListEspecialidades.Items.Insert(0, new ListItem("--- Selecciona una especialidad ---", String.Empty));
        }
    }
}