using System;
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

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public PlanDesktop(int ID, ModoForm modo):this()
        {
            this.Modo = modo;
            PlanLogic planLogic = new PlanLogic();
            PlanActual = planLogic.GetOne(ID);
            MapearDeDatos();
        }

        public Plan PlanActual
        {
            get;
            set;
        }

        public override void MapearDeDatos()
        {
            if (Modo == ModoForm.Alta) this.btnAceptar.Text = "Guardar";
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtID.Text = this.PlanActual.ID.ToString();
                this.txtDescripcion.Text = this.PlanActual.Descripcion;
                this.txtIdEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.PlanActual.ID.ToString();
                this.txtDescripcion.Text = this.PlanActual.Descripcion;
                this.txtIdEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.PlanActual.ID.ToString();
                this.txtDescripcion.Text = this.PlanActual.Descripcion;
                this.txtIdEspecialidad.Text = this.PlanActual.IdEspecialidad.ToString();
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Plan u = new Plan();
                PlanActual = u;
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IdEspecialidad = Int32.Parse(this.txtIdEspecialidad.Text);
                this.PlanActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.PlanActual.ID.ToString();
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IdEspecialidad = Int32.Parse(this.txtIdEspecialidad.Text);
                this.PlanActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.PlanActual.ID.ToString();
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IdEspecialidad = Int32.Parse(this.txtIdEspecialidad.Text);
                this.PlanActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanLogic u = new PlanLogic();
            u.Save(PlanActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                this.Notificar("La descripción es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtIdEspecialidad.Text.Trim()))
            {
                this.Notificar("El id de especialidad ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else { return true; }
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
