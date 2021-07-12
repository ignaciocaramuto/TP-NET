﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            UsuarioActual = usuarioLogic.GetOne(ID);
            MapearDeDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Usuario UsuarioActual
        {
            get;
            set;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion) this.btnAceptar.Text = "Guardar";
            else if (Modo == ModoForm.Baja) this.btnAceptar.Text = "Eliminar";
            else if (Modo == ModoForm.Consulta) this.btnAceptar.Text = "Aceptar";
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario u = new Usuario();
                UsuarioActual = u;
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.State = BusinessEntity.States.New;
            }

            if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.UsuarioActual.ID.ToString();
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.EMail = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.State = BusinessEntity.States.Modified;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic u = new UsuarioLogic();
            u.Save(UsuarioActual);
        }
        public override bool Validar()
        {
            if (this.txtNombre.Text == null || this.txtNombre.Text == "")
            {
                this.Notificar("El nombre ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (this.txtApellido.Text == null || this.txtApellido.Text == "")
            {
                this.Notificar("El apellido ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (!email_bien_escrito(this.txtEmail.Text))
            {
                this.Notificar("El email ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (this.txtUsuario.Text == null || this.txtUsuario.Text == "")
            {
                this.Notificar("El usuario ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (this.txtClave.Text == null || this.txtClave.Text == "")
            {
                this.Notificar("La clave ingresada es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (this.txtConfirmarClave.Text == null || this.txtConfirmarClave.Text == "" || this.txtConfirmarClave.Text != this.txtClave.Text)
            {
                this.Notificar("La clave o confirmación de clave ingresada es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else { return true; }
        }

        public Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public new void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public new void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
