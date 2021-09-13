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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            DocenteCursoLogic docentesCursosLogic = new DocenteCursoLogic();
            DocenteCursoActual = docentesCursosLogic.GetOne(ID);
            MapearDeDatos();
        }

        public DocenteCurso DocenteCursoActual
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
                this.txtID.Text = this.DocenteCursoActual.ID.ToString();
                this.txtIdDocente.Text = this.DocenteCursoActual.IdDocente.ToString();
                this.txtIdCurso.Text = this.DocenteCursoActual.IdCurso.ToString();
                this.txtCargo.Text = this.DocenteCursoActual.Cargo.ToString();
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.DocenteCursoActual.ID.ToString();
                this.txtIdDocente.Text = this.DocenteCursoActual.IdDocente.ToString();
                this.txtIdCurso.Text = this.DocenteCursoActual.IdCurso.ToString();
                this.txtCargo.Text = this.DocenteCursoActual.Cargo.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.DocenteCursoActual.ID.ToString();
                this.txtIdDocente.Text = this.DocenteCursoActual.IdDocente.ToString();
                this.txtIdCurso.Text = this.DocenteCursoActual.IdCurso.ToString();
                this.txtCargo.Text = this.DocenteCursoActual.Cargo.ToString();
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                DocenteCurso dc = new DocenteCurso();
                DocenteCursoActual = dc;
                this.DocenteCursoActual.IdDocente = Int32.Parse(this.txtIdDocente.Text);
                this.DocenteCursoActual.IdCurso = Int32.Parse(this.txtIdCurso.Text);
                this.DocenteCursoActual.Cargo = Int32.Parse(this.txtCargo.Text);
                this.DocenteCursoActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.DocenteCursoActual.ID.ToString();
                this.DocenteCursoActual.IdDocente = Int32.Parse(this.txtIdDocente.Text);
                this.DocenteCursoActual.IdCurso = Int32.Parse(this.txtIdCurso.Text);
                this.DocenteCursoActual.Cargo = Int32.Parse(this.txtCargo.Text);
                this.DocenteCursoActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.DocenteCursoActual.ID.ToString();
                this.DocenteCursoActual.IdDocente = Int32.Parse(this.txtIdDocente.Text);
                this.DocenteCursoActual.IdCurso = Int32.Parse(this.txtIdCurso.Text);
                this.DocenteCursoActual.Cargo = Int32.Parse(this.txtCargo.Text);
                this.DocenteCursoActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            DocenteCursoLogic u = new DocenteCursoLogic();
            u.Save(DocenteCursoActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtIdDocente.Text.Trim()))
            {
                this.Notificar("ID de docente ingresado invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtIdCurso.Text.Trim()))
            {
                this.Notificar("ID de curso ingresado invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtCargo.Text.Trim()))
            {
                this.Notificar("ID de cargo ingresado invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
