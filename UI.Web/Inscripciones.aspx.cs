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
    public partial class Inscripciones : Modes
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGridInscripciones();
            if (this.gridViewInscripciones.SelectedIndex == -1)
            {
                gridActionsPanel.Visible = true;
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

        private int SelectedIDMaterias
        {
            get
            {
                if (this.ViewState["SelectedIDMaterias"] != null)
                    return (int)this.ViewState["SelectedIDMaterias"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDMaterias"] = value;
            }
        }

        private int SelectedIDComisiones
        {
            get
            {
                if (this.ViewState["SelectedIDComisiones"] != null)
                    return (int)this.ViewState["SelectedIDComisiones"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDComisiones"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDInscripciones != 0);
            }
        }

        private void LoadGridInscripciones()
        {
            try
            {
                this.gridViewInscripciones.DataSource = Logic.GetAll(UsuarioActual.Persona.ID);
                this.gridViewInscripciones.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridMaterias()
        {
            try
            {
                MateriaLogic matlog = new MateriaLogic();
                this.gridViewMaterias.DataSource = matlog.GetMateriasParaInscripcion(UsuarioActual.Persona.Plan.ID, UsuarioActual.Persona.ID);
                this.gridViewMaterias.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridComisiones()
        {
            try
            {
                ComisionLogic comlog = new ComisionLogic();
                this.gridViewComisiones.DataSource = comlog.GetComisionesDisponibles(SelectedIDMaterias);
                this.gridViewComisiones.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void EnableForm(bool enable)
        {
            this.gridViewMaterias.Visible = enable;
            this.gridViewComisiones.Visible = enable;
        }

        private void ClearForm()
        {
            this.gridViewInscripciones.SelectedIndex = -1;
            this.gridViewMaterias.SelectedIndex = -1;
            this.gridViewComisiones.DataSource = null;
            this.gridViewComisiones.DataBind();
            this.lblComisiones.Visible = false;
            this.lblMensaje.Visible = false;
            this.btnAceptar.Visible = false;
            this.btnCancelar.Visible = false;
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
            try
            {
                ins.Alumno = UsuarioActual.Persona;
                ins.Condicion = "Inscripto";
                CursoLogic curlog = new CursoLogic();
                foreach (Curso c in curlog.GetAll())
                {
                    if (c.Comision.ID == SelectedIDComisiones && c.Materia.ID == SelectedIDMaterias)
                    {
                        c.Cupo--;
                        ins.Curso = c;
                        ins.Curso.State = BusinessEntity.States.Modified;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
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

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        private bool Validar()
        {
            if (this.SelectedIDComisiones == 0 || this.SelectedIDMaterias == 0)
                return false;
            else return true;
        }

        protected void gridViewInscripciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedIDInscripciones = (int)gridViewInscripciones.DataKeys[rowIndex]["ID"];

                this.eliminarInscripcion();
            }
        }

        protected void eliminarInscripcion()
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedIDInscripciones);
                this.LoadGridInscripciones();
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.gridActionsPanel.Visible = false;
            this.gridViewMaterias.Visible = true;
            this.LoadGridMaterias();
            this.ClearForm();
            this.EnableForm(true);
            this.lblMaterias.Visible = true;
            this.nuevoLinkButton.Visible = false;
            this.btnCancelar.Visible = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.gridViewMaterias.Visible = false;
            this.lblMaterias.Visible = false;
            this.nuevoLinkButton.Visible = true;
            if (this.Validar())
            {
                this.Entity = new AlumnoInscripcion();
                this.LoadEntity(this.Entity);
                if (!Logic.ExisteInscripcion(Entity.Alumno.ID, Entity.Curso.ID))
                {
                    this.SaveEntity(Entity);
                }
                else
                    Response.Write("<script>window.alert('Ya se encuentra inscripto a ese cursado.');</script>");
            }
            this.ClearSession();
            this.ClearForm();
            this.gridActionsPanel.Visible = true;
            this.LoadGridInscripciones();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.gridActionsPanel.Visible = true;
            this.gridViewMaterias.Visible = false;
            this.gridViewComisiones.Visible = false;
            this.lblMaterias.Visible = false;
            this.nuevoLinkButton.Visible = true;
        }

        protected void gridViewMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedIDMaterias = (int)gridViewMaterias.DataKeys[rowIndex]["ID"];
                this.LoadGridComisiones();
                this.lblComisiones.Visible = true;
            }
        }

        protected void gridViewComisiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Inscribirse")
            {
                int rowIndex = int.Parse(e.CommandArgument.ToString());
                SelectedIDComisiones = (int)gridViewComisiones.DataKeys[rowIndex]["ID"];
                this.lblMensaje.Text = "¿Seguro que quiere inscribirse a la materia en la comisión seleccionada?";
                this.lblMensaje.Visible=true;
                this.btnCancelar.Visible = true;
                this.btnAceptar.Visible = true;
            }
        }
    }
}