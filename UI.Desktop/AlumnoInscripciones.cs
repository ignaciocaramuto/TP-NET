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
    public partial class AlumnoInscripciones : Form
    { 
        public AlumnoInscripciones()
        {
            InitializeComponent();
            dgvInscripciones.AutoGenerateColumns = false;
            this.Listar();
        }

        public void Listar()
        {
            AlumnoInscripcionLogic a = new AlumnoInscripcionLogic();
            this.dgvInscripciones.DataSource = a.GetAll();
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop formInscripcion = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formInscripcion.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows != null)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop formInscripcion = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formInscripcion.ShowDialog();
                this.Listar();
            }
        }

        private void tsbBorrar_Click_1(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows != null)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop formInscripcion = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                formInscripcion.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
