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
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            ComisionLogic comisionLogic = new ComisionLogic();
            ComisionActual = comisionLogic.GetOne(ID);
            MapearDeDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Comision ComisionActual
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
                this.txtID.Text = this.ComisionActual.ID.ToString();
                this.txtDescripcion.Text = this.ComisionActual.Descripcion;
                this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
                this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.ComisionActual.ID.ToString();
                this.txtDescripcion.Text = this.ComisionActual.Descripcion;
                this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
                this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.ComisionActual.ID.ToString();
                this.txtDescripcion.Text = this.ComisionActual.Descripcion;
                this.txtAnio.Text = this.ComisionActual.AnioEspecialidad.ToString();
                this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Comision u = new Comision();
                ComisionActual = u;
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnio.Text);
                this.ComisionActual.IdPlan = Int32.Parse(this.txtIdPlan.Text);
                this.ComisionActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.ComisionActual.ID.ToString();
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnio.Text);
                this.ComisionActual.IdPlan = Int32.Parse(this.txtIdPlan.Text);
                this.ComisionActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.ComisionActual.ID.ToString();
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnio.Text);
                this.ComisionActual.IdPlan = Int32.Parse(this.txtIdPlan.Text);
                this.ComisionActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic u = new ComisionLogic();
            u.Save(ComisionActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                this.Notificar("La descripción es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtAnio.Text.Trim()))
            {
                this.Notificar("El año ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
