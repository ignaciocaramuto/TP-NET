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
    public partial class DocentesCursos : ApplicationForm
    {
        public DocentesCursos(Curso c)
        {
            InitializeComponent();
            dgvDocentesCursos.AutoGenerateColumns = false;
            this.cursoActual = c;
        }

        private Curso cursoActual;

        public void Listar()
        {
            try
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                List<DocenteCurso> docentes = new List<DocenteCurso>();
                foreach (DocenteCurso dc in dcl.GetAll())
                {
                    if (dc.Curso.ID == cursoActual.ID)
                        docentes.Add(dc);
                }
                dgvDocentesCursos.DataSource = docentes;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop dcd = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta, cursoActual);
            dcd.ShowDialog();

            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el Docente seleccionado?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    dcl.Delete(ID);
                    this.Listar();
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop dcd = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion, cursoActual);
            dcd.ShowDialog();
            this.Listar();
        }

    }
}
