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
    public partial class DocentesCursos : Modes
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
            if (this.gridView.SelectedIndex == -1)
            {
                gridActionsPanel.Visible = true;
            }
        }

        DocenteCursoLogic _logic;

        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new DocenteCursoLogic();
                return _logic;
            }
        }

        DocenteCurso _Entity;

        private DocenteCurso Entity
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

        private int SelectedIDCurso
        {
            get
            {
                if (Session["ID_Curso"] != null)
                    return (int)this.Session["ID_Curso"];
                else
                    return 0;
            }
            set
            {
                this.Session["ID_Curso"] = value;
            }
        }

        private int SelectedIDDocenteCurso
        {
            get
            {
                if (this.ViewState["ID_DocenteCurso"] != null)
                    return (int)this.ViewState["ID_DocenteCurso"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["ID_DocenteCurso"] = value;
            }
        }

        private int SelectedIDDocente
        {
            get
            {
                if (this.ViewState["ID_Docente"] != null)
                    return (int)this.ViewState["ID_Docente"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["ID_Docente"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDDocenteCurso != 0);
            }
        }

        private void LoadGrid()
        {
            try
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                List<DocenteCurso> docentes = new List<DocenteCurso>();
                foreach (DocenteCurso dc in dcl.GetAll())
                {
                    if (dc.Curso.ID == this.SelectedIDCurso)
                        docentes.Add(dc);
                }
                gridView.DataSource = docentes;
                gridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearForm()
        {
            this.ddlCargo.SelectedValue = "Mensaje";
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
                this.formPanel.Visible = true;
                ddlDocentes.Visible = false;
                this.Entity = this.Logic.GetOne(id);
                lblDocenteSeleccionado.Text = this.Entity.Docente.NombreApellido;
                lblDocenteSeleccionado.Visible = true;
                this.ddlCargo.SelectedValue = this.Entity.Cargo;
            }

            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(DocenteCurso docCurso)
        {
            docCurso.Cargo = this.ddlCargo.SelectedValue;
            if (this.FormMode == FormModes.Alta)
            {
                docCurso.Curso.ID = this.SelectedIDCurso;
                docCurso.Docente.ID = Int32.Parse(this.ddlDocentes.SelectedValue);
            }
        }

        private void SaveEntity(DocenteCurso docCurso)
        {
            try
            {
                this.Logic.Save(docCurso);
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
            this.SelectedIDDocenteCurso = (int)this.gridView.SelectedValue;
        }

        protected void editarDocente(int id)
        {
            if (this.IsEntitySelected)
            {
                this.formPanelActions.Visible = true;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(id);
            }
        }

        protected void eliminarDocente(int id)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(id);
                this.LoadGrid();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entity = this.Logic.GetOne(this.SelectedIDDocenteCurso);
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.ClearSession();
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    if (!Logic.Existe(Entity.Curso.ID, Entity.Docente.ID, Entity.Cargo))
                    {
                        this.SaveEntity(Entity);
                    }
                    else
                        Response.Write("<script>window.alert('Ya se asignó a ese docente, en este curso, para ese cargo.');</script>");
                    this.LoadGrid();
                    this.ClearSession();
                    break;
            }
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.formPanelActions.Visible = false;
        }

        protected void nuevoLinkButton_Click1(object sender, EventArgs e)
        {
            this.lblDocenteSeleccionado.Visible = false;
            this.ddlDocentes.Visible = true;
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.formPanelActions.Visible = true;
            this.LoadDdlDocentes();
        }

        protected void LoadDdlDocentes()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = new List<Persona>();
            foreach (Persona p in pl.GetAll())
            {
                if (p.DescTipoPersona == "Docente")
                {
                    docentes.Add(p);
                }
            }
            this.ddlDocentes.DataSource = docentes;
            this.ddlDocentes.DataTextField = "NombreApellido";
            this.ddlDocentes.DataValueField = "ID";
            this.ddlDocentes.DataBind();
            if (this.FormMode == FormModes.Alta)
            {
                ListItem init = new ListItem();
                init.Text = "--Seleccionar Docente--";
                init.Value = "-1";
                this.ddlDocentes.Items.Add(init);
                this.ddlDocentes.SelectedValue = "-1";
            }
            
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Valida si el nombre del comando de boton es editar o borrar
            if (e.CommandName == "Editar")
            {
                //Determina el index de la fila de donde el boton fue clickeado
                int rowIndex = int.Parse(e.CommandArgument.ToString());

                //Obtiene el valor de la primary key de la fila que fue seleccionada
                SelectedIDDocenteCurso = (int)gridView.DataKeys[rowIndex]["ID"];

                this.editarDocente(SelectedIDDocenteCurso);
            }

            if (e.CommandName == "Borrar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedIDDocenteCurso = (int)gridView.DataKeys[rowIndex]["ID"];

                this.eliminarDocente(SelectedIDDocenteCurso);
            }
        }
    }
}