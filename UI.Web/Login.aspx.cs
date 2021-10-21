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