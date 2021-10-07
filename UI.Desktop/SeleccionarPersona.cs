﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class SeleccionarPersona : ApplicationForm
    {
        public SeleccionarPersona(Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;
            dgvSeleccionarPersona.AutoGenerateColumns = false;
        }

        Usuario usuarioActual;

        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        private void SeleccionarPersona_Load(object sender, EventArgs e)
        {
            this.Listar("Todos");
        }

        public void Listar(string tipo)
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                if (tipo == "Todos")
                    this.dgvSeleccionarPersona.DataSource = pl.GetAll();
                else if (tipo == "Alumnos")
                    this.dgvSeleccionarPersona.DataSource = pl.GetAlumnos();
                else if (tipo == "Docentes")
                    this.dgvSeleccionarPersona.DataSource = pl.GetDocentes();
                else if (tipo == "No docentes")
                    this.dgvSeleccionarPersona.DataSource = pl.GetNoDocentes();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Listar(cbxTipoPersona.SelectedItem.ToString());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            usuarioActual.Persona = ((Persona)this.dgvSeleccionarPersona.SelectedRows[0].DataBoundItem);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
