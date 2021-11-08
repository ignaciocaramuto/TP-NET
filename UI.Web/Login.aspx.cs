using System;
using System.Web.UI;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : Modes
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        UsuarioLogic _logic;

        public UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new UsuarioLogic();
                return _logic;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuarioActual = Logic.GetUsuarioForLogin(this.txtUsuario.Text, this.txtContraseña.Text);
                if (this.txtUsuario.Text == "admin")
                {
                    this.Session["Privilegio"] = "Admin";
                }
                else if (usuarioActual.TipoPersona == "Docente")
                {
                    this.Session["Privilegio"] = "Docente";
                }
                else if (usuarioActual.TipoPersona == "No docente")
                {
                    this.Session["Privilegio"] = "No docente";
                }
                else if (usuarioActual.TipoPersona == "Alumno")
                {
                     this.Session["Privilegio"] = "Alumno";
                }
                

                if (usuarioActual.ID != 0)
                {
                    if (usuarioActual.Habilitado)
                    {
                        ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                        usuarioActual.ModulosUsuarios = mul.GetPermisos(usuarioActual.ID);
                        Session["UsuarioActual"] = usuarioActual;
                        Page.Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }
    }
}