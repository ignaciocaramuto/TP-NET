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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            EspecialidadActual = especialidadLogic.GetOne(ID);
            MapearDeDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Especialidad EspecialidadActual
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
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
                this.txtDescripcion.Text = this.EspecialidadActual.Descripcion; 
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
                this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
                this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
                
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Especialidad e = new Especialidad();
                EspecialidadActual = e;
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                this.EspecialidadActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                this.EspecialidadActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.EspecialidadActual.ID.ToString();
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
                this.EspecialidadActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadLogic e = new EspecialidadLogic();
            e.Save(EspecialidadActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
            {
                this.Notificar("La descripción es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
