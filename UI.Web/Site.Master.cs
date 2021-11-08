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
            if (!IsPostBack)
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

                        hideABMC.Visible = false;

                        HyperLinkReporteCursos.Visible = false;
                        HyperLinkReportePlanes.Visible = false;
                        hideReporteCursos.Visible = false;
                        hideReportePlanes.Visible = false;
                    }
                    else if (UsuarioActual.Persona.DescTipoPersona == "Docente")
                    {
                        HyperLinkInscripciones.Visible = false;
                        hideInscripcion.Visible = false;

                        HyperLinkNotas.Visible = true;
                        hideNotas.Visible = true;

                        hideABMC.Visible = false;

                        HyperLinkReporteCursos.Visible = false;
                        HyperLinkReportePlanes.Visible = false;
                        hideReporteCursos.Visible = false;
                        hideReportePlanes.Visible = false;
                    }
                    else if (UsuarioActual.Persona.DescTipoPersona == "No docente")
                    {
                        HyperLinkInscripciones.Visible = false;
                        hideInscripcion.Visible = false;

                        HyperLinkNotas.Visible = false;
                        hideNotas.Visible = false;

                        hideABMC.Visible = true;

                        HyperLinkReporteCursos.Visible = true;
                        HyperLinkReportePlanes.Visible = true;
                        hideReporteCursos.Visible = true;
                        hideReportePlanes.Visible = true;
                    }
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