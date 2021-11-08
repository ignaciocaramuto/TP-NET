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
    public partial class Materias : Modes
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

        MateriaLogic _logic;

        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new MateriaLogic();
                return _logic;
            }
        }

        PlanLogic logic;

        private PlanLogic PlanLogic
        {
            get
            {
                if (logic == null)
                    logic = new PlanLogic();
                return logic;
            }
        }

        EspecialidadLogic logic_esp;

        private EspecialidadLogic EspecialidadLogic
        {
            get
            {
                if (logic_esp == null)
                    logic_esp = new EspecialidadLogic();
                return logic_esp;
            }
        }

        Materia _Entity;

        private Materia Entity
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
                this.ViewState["SelectedID"] = value;
            }
        }

        private void LoadGrid()
        {
            try
            {
                gridView.DataSource = this.Logic.GetAll();
                gridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadDdlPlanes()
        {
            List<Plan> planes = new List<Plan>();
            foreach (Plan p in PlanLogic.GetAll())
            {
                if (p.Especialidad.ID == Convert.ToInt32(ddlEspecialidades.SelectedValue))
                {
                    planes.Add(p);
                }
            }
            ddlPlanes.DataSource = planes;
            ddlPlanes.DataTextField = "Descripcion";
            ddlPlanes.DataValueField = "ID";
            ddlPlanes.DataBind();
        }

        private void EnableForm(bool enable)
        {
            formPanel.Visible = enable;
        }

        private void ClearForm()
        {
            txtDescripcion.Text = string.Empty;
            txtHsSemanales.Text = string.Empty;
            txtHsTotales.Text = string.Empty;
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
                txtHsSemanales.Text = Entity.HSSemanales.ToString();
                txtHsTotales.Text = Entity.HSTotales.ToString();
                ddlEspecialidades.SelectedValue = Entity.Plan.Especialidad.ID.ToString();
                LoadDdlPlanes();
                ddlPlanes.SelectedValue = Entity.Plan.ID.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(Materia mat)
        {
            mat.Descripcion = txtDescripcion.Text;
            mat.HSSemanales = Convert.ToInt32(txtHsSemanales.Text);
            mat.HSTotales = Convert.ToInt32(txtHsTotales.Text);
            mat.Plan.Especialidad.ID = Convert.ToInt32(ddlEspecialidades.SelectedValue);
            mat.Plan.ID = Convert.ToInt32(ddlPlanes.SelectedValue);
        }

        private void SaveEntity(Materia mat)
        {
            try
            {
                this.Logic.Save(mat);
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
            ddlEspecialidadesLoad();
            formPanel.Visible = true;
            gridActionsPanel.Visible = false;
            formPanelActions.Visible = true;
            txtDescripcion.ReadOnly = false;
            txtHsSemanales.ReadOnly = false;
            txtHsTotales.ReadOnly = false;
            ddlEspecialidades.Enabled = true;
            ddlPlanes.Enabled = true;
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
                        Entity = Logic.GetOne(SelectedID);
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                    }
                    break;
                case FormModes.Alta:
                    Entity = new Materia();
                    LoadEntity(Entity);
                    if (!Logic.Existe(Entity.Plan.ID, Entity.Descripcion))
                    {
                        SaveEntity(Entity);
                    }
                    else
                        Response.Write("<script>window.alert('La Materia ya existe.');</script>");
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
            EnableForm(false);
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
                txtHsSemanales.ReadOnly = false;
                txtHsTotales.ReadOnly = false;
                ddlEspecialidades.Enabled = true;
                ddlPlanes.Enabled = true;
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
                txtHsSemanales.ReadOnly = true;
                txtHsTotales.ReadOnly = true;
                ddlEspecialidades.Enabled = false;
                ddlPlanes.Enabled = false;
                formPanelActions.Visible = true;
                EnableForm(true);
                FormMode = FormModes.Baja;
                LoadForm(SelectedID);
            }
        }

        private void ddlEspecialidadesLoad()
        {
            try
            {
                List<Especialidad> especialidades = EspecialidadLogic.GetAll();

                ddlEspecialidades.DataSource = especialidades;
                ddlEspecialidades.DataValueField = "ID";
                ddlEspecialidades.DataTextField = "Descripcion";
                ddlEspecialidades.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        protected void ddlEspecialidades_DataBound(object sender, EventArgs e)
        {
            //Establece como item por defecto el string "selecciona una persona"
            ddlEspecialidades.Items.Insert(0, new ListItem("--- Seleccione una especialidad ---", String.Empty));
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDdlPlanes();
        }
    }
}