using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActual"] != null)
            {
                Business.Entities.Usuario UsuarioActual = (Business.Entities.Usuario)Session["UsuarioActual"];
                
                if (UsuarioActual.Persona.DescTipoPersona == "Alumno")
                {
                    HyperLinkInscripciones.Visible = true;
                    hideInscripcion.Visible = true;

                    HyperLinkNotas.Visible = false;
                    hideNotas.Visible = false;

                    HyperLinkUsuarios.Visible = false;
                    hideUsuarios.Visible = false;

                    HyperLinkComisiones.Visible = false;
                    hideComisiones.Visible = false;

                    HyperLinkCursos.Visible = false;
                    hideCursos.Visible = false;

                    HyperLinkEspecialidades.Visible = false;
                    hideEspecialidades.Visible = false;

                    HyperLinkPlanes.Visible = false;
                    hidePlanes.Visible = false;

                    HyperLinkMaterias.Visible = false;
                    hideMaterias.Visible = false;

                    HyperLinkReportes.Visible = false;
                    hideReportes.Visible = false;
                }
                else if (UsuarioActual.Persona.DescTipoPersona == "Docente")
                {
                    HyperLinkInscripciones.Visible = false;
                    hideInscripcion.Visible = false;

                    HyperLinkNotas.Visible = true;
                    hideNotas.Visible = true;

                    HyperLinkUsuarios.Visible = false;
                    hideUsuarios.Visible = false;

                    HyperLinkComisiones.Visible = false;
                    hideComisiones.Visible = false;

                    HyperLinkCursos.Visible = false;
                    hideCursos.Visible = false;

                    HyperLinkEspecialidades.Visible = false;
                    hideEspecialidades.Visible = false;

                    HyperLinkPlanes.Visible = false;
                    hidePlanes.Visible = false;

                    HyperLinkMaterias.Visible = false;
                    hideMaterias.Visible = false;

                    HyperLinkReportes.Visible = false;
                    hideReportes.Visible = false;
                }
                else if (UsuarioActual.Persona.DescTipoPersona == "No docente")
                {
                    HyperLinkInscripciones.Visible = false;
                    hideInscripcion.Visible = false;

                    HyperLinkNotas.Visible = false;
                    hideNotas.Visible = false;

                    HyperLinkUsuarios.Visible = true;
                    hideUsuarios.Visible = true;

                    HyperLinkComisiones.Visible = true;
                    hideComisiones.Visible = true;

                    HyperLinkCursos.Visible = true;
                    hideCursos.Visible = true;

                    HyperLinkEspecialidades.Visible = true;
                    hideEspecialidades.Visible = true;

                    HyperLinkPlanes.Visible = true;
                    hidePlanes.Visible = true;

                    HyperLinkMaterias.Visible = true;
                    hideMaterias.Visible = true;

                    HyperLinkReportes.Visible = true;
                    hideReportes.Visible = true;
                }
                                
            } 
        }
        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["UsuarioActual"] = null;
            Page.Response.Redirect("~/Login.aspx");
        }
    }
}