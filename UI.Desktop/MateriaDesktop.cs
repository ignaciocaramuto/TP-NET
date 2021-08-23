using System;
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
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public Materia MateriaActual
        {
            get;
            set;
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            MateriaLogic materiaLogic = new MateriaLogic();
            MateriaActual = materiaLogic.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            if (Modo == ModoForm.Alta) this.btnAceptar.Text = "Guardar";
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtID.Text = this.MateriaActual.ID.ToString();
                this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
                this.txtHs_Semanales.Text = this.MateriaActual.HsSemanales.ToString();
                this.txtHs_Totales.Text = this.MateriaActual.HsTotales.ToString();
                this.txtID_Plan.Text = this.MateriaActual.IdPlan.ToString();

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.MateriaActual.ID.ToString();
                this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
                this.txtHs_Semanales.Text = this.MateriaActual.HsSemanales.ToString();
                this.txtHs_Totales.Text = this.MateriaActual.HsTotales.ToString();
                this.txtID_Plan.Text = this.MateriaActual.IdPlan.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.MateriaActual.ID.ToString();
                this.txtDescripcion.Text = this.MateriaActual.Descripcion.ToString();
                this.txtHs_Semanales.Text = this.MateriaActual.HsSemanales.ToString();
                this.txtHs_Totales.Text = this.MateriaActual.HsTotales.ToString();
                this.txtID_Plan.Text = this.MateriaActual.IdPlan.ToString();
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Materia m = new Materia();
                MateriaActual = m;
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = int.Parse(this.txtHs_Semanales.Text);
                this.MateriaActual.HsTotales = int.Parse(this.txtHs_Totales.Text);
                this.MateriaActual.IdPlan = int.Parse(this.txtID_Plan.Text);
                this.MateriaActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.MateriaActual.ID.ToString();
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = int.Parse(this.txtHs_Semanales.Text);
                this.MateriaActual.HsTotales = int.Parse(this.txtHs_Totales.Text);
                this.MateriaActual.IdPlan = int.Parse(this.txtID_Plan.Text);
                this.MateriaActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.MateriaActual.ID.ToString();
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HsSemanales = int.Parse(this.txtHs_Semanales.Text);
                this.MateriaActual.HsTotales = int.Parse(this.txtHs_Totales.Text);
                this.MateriaActual.IdPlan = int.Parse(this.txtID_Plan.Text);
                this.MateriaActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic m = new MateriaLogic();
            m.Save(MateriaActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                this.Notificar("El ID de materia ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtHs_Semanales.Text.Trim()))
            {
                this.Notificar("El año ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtHs_Totales.Text.Trim()))
            {
                this.Notificar("El cupo ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtID_Plan.Text.Trim()))
            {
                this.Notificar("El ID de comision ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
