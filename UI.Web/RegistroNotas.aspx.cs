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
    public partial class RegistroNotas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["Privilegio"] != "Docente")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            else
            {
                this.LoadGridCursos();
                if (this.gridViewCursos.SelectedIndex == -1)
                {
                    formPanel.Visible = false;
                    formPanelActions.Visible = false;
                }
            }
        }

        AlumnoInscripcionLogic _logic;

        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AlumnoInscripcionLogic();
                return _logic;
            }
        }

        AlumnoInscripcion _Entity;

        private AlumnoInscripcion Entity
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

        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }

        private int SelectedIDCursos
        {
            get
            {
                if (this.ViewState["SelectedIDCursos"] != null)
                    return (int)this.ViewState["SelectedIDCursos"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDCursos"] = value;
            }
        }

        private int SelectedIDInscripciones
        {
            get
            {
                if (this.ViewState["SelectedIDInscripciones"] != null)
                    return (int)this.ViewState["SelectedIDInscripciones"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDInscripciones"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDInscripciones != 0);
            }
        }

        private void LoadGridCursos()
        {
            try
            {
                CursoLogic curlog = new CursoLogic();
                this.gridViewCursos.DataSource = curlog.GetCursosDocente(UsuarioActual.Persona.ID);
                this.gridViewCursos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridAlumnos()
        {
            try
            {
                List<AlumnoInscripcion> alumnosInscriptos = new List<AlumnoInscripcion>();
                foreach (AlumnoInscripcion ai in Logic.GetAll())
                {
                    if (ai.Curso.ID == this.SelectedIDCursos)
                        alumnosInscriptos.Add(ai);
                }
                this.gridViewAlumnos.DataSource = alumnosInscriptos;
                this.gridViewAlumnos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }


        private void EnableForm(bool enable)
        {
            this.gridViewAlumnos.Visible = enable;
        }

        private void ClearForm()
        {
            this.lblAlumnos.Visible = false;
            this.gridViewAlumnos.Visible = false;
            this.btnVolver.Visible = false;
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

        private void LoadEntity(AlumnoInscripcion ins)
        {
            ins.Nota = Convert.ToInt32(this.ddlNotas.SelectedValue);
            ins.Condicion = this.ddlCondiciones.SelectedValue;
        }

        private void SaveEntity(AlumnoInscripcion ins)
        {
            try
            {
                this.Logic.Save(ins);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridViewCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCursos = (int)this.gridViewCursos.SelectedValue;
            this.LoadGridAlumnos();
            this.formPanel.Visible = true;
        }

        protected void GridViewAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDInscripciones = (int)this.gridViewAlumnos.SelectedValue;
        }

        private bool Validar()
        {
            if (this.SelectedIDInscripciones == 0)
                return false;
            else return true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.btnVolver.Visible = true;
            if (this.Validar())
            {
                this.Entity = Logic.GetOne(SelectedIDInscripciones);
                this.Entity.State = BusinessEntity.States.Modified;
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
            }
            this.LoadGridAlumnos();
        }

        protected void gridViewCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedIDCursos = (int)gridViewCursos.DataKeys[rowIndex]["ID"];
                this.LoadGridAlumnos();
                this.btnVolver.Visible = true;
                this.gridViewAlumnos.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        protected void gridViewAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                if (this.IsEntitySelected)
                {
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    SelectedIDInscripciones = (int)gridViewAlumnos.DataKeys[rowIndex]["ID"];
                    this.Entity = Logic.GetOne(SelectedIDInscripciones);
                    this.Entity.Nota = 0;
                    this.Entity.Condicion = "Inscripto";
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.SaveEntity(this.Entity);
                    this.LoadGridAlumnos();
                }
            }

            if (e.CommandName == "Modificar")
            {
                
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    SelectedIDInscripciones = (int)gridViewAlumnos.DataKeys[rowIndex]["ID"];
                    this.formPanel.Visible = true;
                    this.formPanelActions.Visible = true;
                    this.btnVolver.Visible = false;
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            this.btnVolver.Visible = true;
            this.formPanel.Visible = false;
            this.LoadGridAlumnos();
        }
    }
}