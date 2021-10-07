﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }

        Comision comisionActual;

        public Comision ComisionActual
        {
            get { return comisionActual; }
            set { comisionActual = value; }
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.LlenarComboEspecialidades();
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            ComisionLogic ComisionNegocio = new ComisionLogic();
            try
            {
                comisionActual = ComisionNegocio.GetOne(ID);
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
                cbxPlan.DataSource = planes;
                cbxPlan.DisplayMember = "Descripcion";
                cbxPlan.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = ComisionActual.ID.ToString();
            this.txtDescripcion.Text = ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = ComisionActual.AnioEspecialidad.ToString();
            this.cbxEspecialidades.SelectedValue = ComisionActual.Plan.Especialidad.ID;
            this.LlenarComboPlanes();
            this.cbxPlan.SelectedValue = ComisionActual.Plan.ID;

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
                    ComisionActual.State = Comision.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = Comision.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.State = Comision.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = Comision.States.Modified;
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Modificacion)
                ComisionActual.ID = Convert.ToInt32(this.txtID.Text);
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);
                ComisionActual.Plan.ID = Convert.ToInt32(this.cbxPlan.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                ComisionLogic comisionLogic = new ComisionLogic();
                if (Modo != ModoForm.Alta || !comisionLogic.Existe(comisionActual.Plan.ID, comisionActual.Descripcion))
                    comisionLogic.Save(ComisionActual);
                else this.Notificar("Ya existe esta Comisión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.cbxEspecialidades.SelectedItem == null || this.cbxPlan.SelectedItem == null)
                EsValido = false;
            if (this.txtDescripcion.Text == String.Empty || this.txtAnioEspecialidad.Text == String.Empty)
                EsValido = false;
            if (EsValido == false)
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.LlenarComboPlanes();
        }
    }
}