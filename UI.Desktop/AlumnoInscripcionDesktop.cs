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
    public partial class InscripcionDesktop : ApplicationForm
    {
        public InscripcionDesktop(Usuario u)
        {
            InitializeComponent();
            this.usuarioActual = u;
            this.inscripcionActual = new AlumnoInscripcion();
            this.inscripcionActual.State = BusinessEntity.States.New;
        }

        private void InscripcionCurso_Load(object sender, EventArgs e)
        {
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvMaterias.AutoGenerateColumns = false;
            this.ListarMaterias();
        }

        private Usuario usuarioActual;

        private AlumnoInscripcion inscripcionActual;

        private void ListarMaterias()
        {
            try
            {
                MateriaLogic matlog = new MateriaLogic();
                this.dgvMaterias.DataSource = matlog.GetMateriasParaInscripcion(usuarioActual.Persona.Plan.ID, usuarioActual.Persona.ID);
                this.dgvMaterias.ClearSelection();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearADatos()
        {
            try
            {
                inscripcionActual.Alumno = usuarioActual.Persona;
                inscripcionActual.Condicion = "Inscripto";
                CursoLogic curlog = new CursoLogic();
                int IDMateria = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int IDComision = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                foreach (Curso c in curlog.GetAll())
                {
                    if (c.Comision.ID == IDComision && c.Materia.ID == IDMateria)
                    {
                        c.Cupo--;
                        inscripcionActual.Curso = c;
                        inscripcionActual.Curso.State = BusinessEntity.States.Modified;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IDMateria = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                ComisionLogic comlog = new ComisionLogic();
                this.dgvComisiones.DataSource = comlog.GetComisionesDisponibles(IDMateria);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                AlumnoInscripcionLogic inslogic = new AlumnoInscripcionLogic();
                if (Modo != ModoForm.Alta || !inslogic.ExisteInscripcion(inscripcionActual.Alumno.ID, inscripcionActual.Curso.ID))
                {
                    inslogic.Save(inscripcionActual);
                    CursoLogic curlog = new CursoLogic();
                    curlog.Save(inscripcionActual.Curso);
                }
                else this.Notificar("Ya estas inscripto a este Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count > 0)
            {
                var rta = MessageBox.Show("Se esta inscribiendo a la Materia: " + ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Descripcion +
                    " en la Comision: " + ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Descripcion, "Atencion", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else
                this.Notificar("Seleccione una comision a la cual inscribirse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



    }
}
