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
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public Curso CursoActual
        {
            get;
            set;
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic cursoLogic = new CursoLogic();
            CursoActual = cursoLogic.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            if (Modo == ModoForm.Alta) this.btnAceptar.Text = "Guardar";
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
                this.txtID.Text = this.CursoActual.ID.ToString();
                this.txtIDMateria.Text = this.CursoActual.IdMateria.ToString();
                this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
                this.txtIDComision.Text = this.CursoActual.IdComision.ToString();
                this.txtCupo.Text = this.CursoActual.Cupo.ToString();

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.CursoActual.ID.ToString();
                this.txtIDMateria.Text = this.CursoActual.IdMateria.ToString();
                this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
                this.txtIDComision.Text = this.CursoActual.IdComision.ToString();
                this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.CursoActual.ID.ToString();
                this.txtIDMateria.Text = this.CursoActual.IdMateria.ToString();
                this.txtAñoCalendario.Text = this.CursoActual.AnioCalendario.ToString();
                this.txtIDComision.Text = this.CursoActual.IdComision.ToString();
                this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Curso c = new Curso();
                CursoActual = c;
                this.CursoActual.IdMateria = int.Parse(this.txtIDMateria.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAñoCalendario.Text);
                this.CursoActual.IdComision = int.Parse(this.txtIDComision.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                this.CursoActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.CursoActual.ID.ToString();
                this.CursoActual.IdMateria = int.Parse(this.txtIDMateria.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAñoCalendario.Text);
                this.CursoActual.IdComision = int.Parse(this.txtIDComision.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                this.CursoActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.CursoActual.ID.ToString();
                this.CursoActual.IdMateria = int.Parse(this.txtIDMateria.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAñoCalendario.Text);
                this.CursoActual.IdComision = int.Parse(this.txtIDComision.Text);
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                this.CursoActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            CursoLogic c = new CursoLogic();
            c.Save(CursoActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtIDMateria.Text.Trim()))
            {
                this.Notificar("El ID de materia ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtAñoCalendario.Text.Trim()))
            {
                this.Notificar("El año ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtCupo.Text.Trim()))
            {
                this.Notificar("El cupo ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtIDComision.Text.Trim()))
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
