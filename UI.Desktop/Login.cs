﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private Usuario usuarioActual;

        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioLogic user = new UsuarioLogic();
            try
            {
                usuarioActual = user.GetUsuarioForLogin(txtUsuario.Text, txtClave.Text);
                if (usuarioActual.ID != 0)
                {
                    if (usuarioActual.Habilitado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.Notificar("El Usuario no está habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtClave.Clear();
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

