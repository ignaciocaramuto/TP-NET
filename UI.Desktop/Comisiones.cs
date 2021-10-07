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
    public partial class Comisiones : ApplicationForm
    {
        private Usuario usuarioActual;

        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }
        public Comisiones(Usuario us)
        {
            InitializeComponent();
            UsuarioActual = us;
            dgvComisiones.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                dgvComisiones.DataSource = cl.GetAll();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Comisiones")
                {
                    this.dgvComisiones.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop ComisionDesktop = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            ComisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop ComisionDesktop = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            ComisionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar la Comision seleccionada?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    if (this.dgvComisiones.SelectedRows.Count > 0)
                    {
                        int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                        ComisionLogic comision = new ComisionLogic();
                        comision.Delete(ID);
                        this.Listar();
                    }
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}