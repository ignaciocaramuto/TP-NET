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
    public partial class Comisiones : Modes
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Privilegio"] != "Admin")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            else
            {
                this.LoadGrid();
                if (this.gridView.SelectedIndex == -1)
                {

                    gridActionsPanel.Visible = true;
                }
            }

            
        }

        ComisionLogic _logic;

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new ComisionLogic();
                return _logic;
            }
        }

        Comision _Entity;

        private Comision Entity
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
                if (this.ViewState["SelectedID"] != null)
                    return (int)this.ViewState["SelectedID"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid()
        {
            try
            {
                this.gridView.DataSource = this.Logic.GetAll();
                this.gridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

      

        private void LoadDdlEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.ddlEspecialidades.DataSource = el.GetAll();
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Especialidad--";
            init.Value = "-1";
            this.ddlEspecialidades.Items.Add(init);
            this.ddlEspecialidades.SelectedValue = "-1";
        }

        private void LoadDdlPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = new List<Plan>();
            foreach (Plan p in pl.GetAll())
            {
                if (p.Especialidad.ID == Convert.ToInt32(this.ddlEspecialidades.SelectedValue))
                {
                    planes.Add(p);
                }
            }
            this.ddlPlanes.DataSource = planes;
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataValueField = "ID";
            this.ddlPlanes.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Plan--";
            init.Value = "-1";
            this.ddlPlanes.Items.Add(init);
            this.ddlPlanes.SelectedValue = "-1";
        }

        private void EnableForm(bool enable)
        {
            this.lblDescripcion.Visible = enable;
            this.txtDescripcion.Visible = enable;
            this.lblAnioEspecialidad.Visible = enable;
            this.txtAnio.Visible = enable;
            this.lblEspecialidad.Visible = enable;
            this.ddlEspecialidades.Visible = enable;
            this.lblPlan.Visible = enable;
            this.ddlPlanes.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtAnio.Text = string.Empty;
            this.ddlPlanes.Items.Clear();
            this.gridView.SelectedIndex = -1;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Logic.Delete(id);
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
                this.Entity = this.Logic.GetOne(id);
                this.txtDescripcion.Text = this.Entity.Descripcion;
                this.txtAnio.Text = this.Entity.AnioEspecialidad.ToString();
                this.ddlEspecialidades.SelectedValue = this.Entity.Plan.Especialidad.ID.ToString();
                this.LoadDdlPlanes();
                this.ddlPlanes.SelectedValue = this.Entity.Plan.ID.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }


        private void LoadEntity(Comision comi)
        {
            comi.Descripcion = this.txtDescripcion.Text;
            comi.AnioEspecialidad = Convert.ToInt32(this.txtAnio.Text);
            comi.Plan.ID = Convert.ToInt32(this.ddlPlanes.SelectedValue);
            comi.Plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue);            
        }

        private void SaveEntity(Comision comi)
        {
            try
            {
                this.Logic.Save(comi);
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
           
        }

        protected void editarComision (int id)
        {
                       
                this.LoadDdlEspecialidades();
                this.gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(id);
                this.formPanelActions.Visible = true;

            
        }

        protected void eliminarComision(int id)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(id);
                this.LoadGrid();
                
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadDdlEspecialidades();
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.formPanelActions.Visible = true;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entity = this.Logic.GetOne(this.SelectedID);
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.ClearSession();
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
                    this.LoadEntity(this.Entity);
                    if (!Logic.Existe(Entity.Plan.ID, Entity.Descripcion))
                    {
                        this.SaveEntity(Entity);
                    }
                    else
                        Response.Write("<script>window.alert('La Comision ya existe.');</script>");
                    this.LoadGrid();
                    this.ClearSession();
                    break;
            }
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.LoadGrid();
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gridActionsPanel.Visible = false;
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlPlanes();
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Valida si el nombre del comando de boton es editar o borrar
            if (e.CommandName == "Editar")
            {
                //Determina el index de la fila de donde el boton fue clickeado
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                //Obtiene el valor de la primary key de la fila que fue seleccionada
                SelectedID = (int)gridView.DataKeys[rowIndex]["ID"];

                this.editarComision(SelectedID);
            }

            if (e.CommandName == "Borrar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedID = (int)gridView.DataKeys[rowIndex]["ID"];

                this.eliminarComision(SelectedID);
            }
        }
    }
}