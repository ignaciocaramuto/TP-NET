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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public AlumnoInscripcionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            AlumnoInscripcionLogic inscripcionLogic = new AlumnoInscripcionLogic();
            InscripcionActual = inscripcionLogic.GetOne(ID);
            MapearDeDatos();
        }

        public AlumnoInscripcion InscripcionActual
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
                this.txtID.Text = this.InscripcionActual.ID.ToString();
                this.txtIdAlumno.Text = this.InscripcionActual.IdAlumno.ToString();
                this.txtIdCurso.Text = this.InscripcionActual.IdCurso.ToString();
                this.txtCondicion.Text = this.InscripcionActual.Condicion;
                this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.InscripcionActual.ID.ToString();
                this.txtIdAlumno.Text = this.InscripcionActual.IdAlumno.ToString();
                this.txtIdCurso.Text = this.InscripcionActual.IdCurso.ToString();
                this.txtCondicion.Text = this.InscripcionActual.Condicion;
                this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.InscripcionActual.ID.ToString();
                this.txtIdAlumno.Text = this.InscripcionActual.IdAlumno.ToString();
                this.txtIdCurso.Text = this.InscripcionActual.IdCurso.ToString();
                this.txtCondicion.Text = this.InscripcionActual.Condicion;
                this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                AlumnoInscripcion a = new AlumnoInscripcion();
                InscripcionActual = a;
                this.InscripcionActual.IdAlumno = Int32.Parse(this.txtIdAlumno.Text);
                this.InscripcionActual.IdCurso = Int32.Parse(this.txtIdCurso.Text);
                this.InscripcionActual.Condicion = this.txtCondicion.Text;
                this.InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                this.InscripcionActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.InscripcionActual.ID.ToString();
                this.InscripcionActual.IdAlumno = Int32.Parse(this.txtIdAlumno.Text);
                this.InscripcionActual.IdCurso = Int32.Parse(this.txtIdCurso.Text);
                this.InscripcionActual.Condicion = this.txtCondicion.Text;
                this.InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                this.InscripcionActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.InscripcionActual.ID.ToString();
                this.InscripcionActual.IdAlumno = Int32.Parse(this.txtIdAlumno.Text);
                this.InscripcionActual.IdCurso = Int32.Parse(this.txtIdCurso.Text);
                this.InscripcionActual.Condicion = this.txtCondicion.Text;
                this.InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                this.InscripcionActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoInscripcionLogic a = new AlumnoInscripcionLogic();
            a.Save(InscripcionActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtIdAlumno.Text.Trim()))
            {
                this.Notificar("El ID de alumno es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtIdCurso.Text.Trim()))
            {
                this.Notificar("El ID de curso es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtCondicion.Text.Trim()))
            {
                this.Notificar("La condicion ingresada es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtNota.Text.Trim()) || (Int32.Parse(this.txtNota.Text.Trim())) < 0 || (Int32.Parse(this.txtNota.Text.Trim())) > 10)
            {
                this.Notificar("La nota ingresada es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
