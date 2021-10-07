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
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

        Curso cursoActual;

        public Curso CursoActual
        {
            get { return cursoActual; }
            set { cursoActual = value; }
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.LlenarComboEspecialidades();
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic CursoNegocio = new CursoLogic();
            try
            {
                cursoActual = CursoNegocio.GetOne(ID);
                this.LlenarComboEspecialidades();
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboEspecialidades()
        {
            try
            {
                EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
                cbxEspecialidades.DataSource = EspecialidadNegocio.GetAll();
                cbxEspecialidades.DisplayMember = "Descripcion";
                cbxEspecialidades.ValueMember = "ID";
                cbxEspecialidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboPlanes()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                List<Plan> planes = new List<Plan>();
                foreach (Plan p in pl.GetAll())
                {
                    if (p.Especialidad.ID == Convert.ToInt32(cbxEspecialidades.SelectedValue))
                    {
                        planes.Add(p);
                    }
                }
                cbxPlanes.DataSource = planes;
                cbxPlanes.DisplayMember = "Descripcion";
                cbxPlanes.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboMaterias()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                List<Materia> materias = new List<Materia>();
                foreach (Materia m in ml.GetAll())
                {
                    if (m.Plan.ID == Convert.ToInt32(cbxPlanes.SelectedValue))
                        materias.Add(m);
                }
                cbxMaterias.DataSource = materias;
                cbxMaterias.DisplayMember = "Descripcion";
                cbxMaterias.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboComisiones()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                List<Comision> comisiones = new List<Comision>();
                foreach (Comision c in cl.GetAll())
                {
                    if (c.Plan.ID == Convert.ToInt32(cbxPlanes.SelectedValue))
                        comisiones.Add(c);
                }
                cbxComisiones.DataSource = comisiones;
                cbxComisiones.DisplayMember = "Descripcion";
                cbxComisiones.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = CursoActual.ID.ToString();
            this.txtCupo.Text = CursoActual.Cupo.ToString();
            this.txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            this.cbxEspecialidades.SelectedValue = cursoActual.Comision.Plan.Especialidad.ID;
            this.LlenarComboPlanes();
            this.cbxPlanes.SelectedValue = cursoActual.Comision.Plan.ID;
            this.LlenarComboComisiones();
            this.cbxComisiones.SelectedValue = cursoActual.Comision.ID;
            this.LlenarComboMaterias();
            this.cbxMaterias.SelectedValue = cursoActual.Materia.ID;

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Baja:
                    CursoActual.State = Curso.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = Curso.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    CursoActual.State = Curso.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = Curso.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                    CursoActual.ID = Convert.ToInt32(this.txtID.Text);
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
                CursoActual.Comision.ID = Convert.ToInt32(this.cbxComisiones.SelectedValue);
                CursoActual.Materia.ID = Convert.ToInt32(this.cbxMaterias.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                CursoLogic CursoLogic = new CursoLogic();
                if (Modo != ModoForm.Alta || !CursoLogic.Existe(cursoActual.Materia.ID, cursoActual.Comision.ID, cursoActual.AnioCalendario))
                    CursoLogic.Save(CursoActual);
                else this.Notificar("Ya existe este Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.cbxComisiones.SelectedItem == null || this.cbxEspecialidades.SelectedItem == null ||
                this.cbxPlanes.SelectedItem == null || this.cbxMaterias.SelectedItem == null ||
                this.txtAnioCalendario.Text == String.Empty || this.txtCupo.Text == String.Empty)
            {
                EsValido = false;
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return EsValido;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cbxPlanes.SelectedIndex = -1;
            this.LlenarComboPlanes();
        }

        private void cbxPlanes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cbxMaterias.SelectedIndex = this.cbxComisiones.SelectedIndex = -1;
            this.LlenarComboMaterias();
            this.LlenarComboComisiones();
        }
    }
}