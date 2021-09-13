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
    public partial class DocentesCursos : Form
    {
        public DocentesCursos()
        {
            InitializeComponent();
            dgvDocentesCursos.AutoGenerateColumns = false;
            this.Listar();
        }

        public void Listar()
        {
            DocenteCursoLogic cl = new DocenteCursoLogic();
            this.dgvDocentesCursos.DataSource = cl.GetAll();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocenteCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCursos.SelectedRows != null)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formDocenteCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCursos.SelectedRows != null)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formDocenteCurso.ShowDialog();
                this.Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
