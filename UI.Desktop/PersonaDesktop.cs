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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
            MapearDeDatos();
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PersonaLogic personasLogic = new PersonaLogic();
            PersonaActual = personasLogic.GetOne(ID);
            MapearDeDatos();
        }

        public Persona PersonaActual
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
                this.txtID.Text = this.PersonaActual.ID.ToString();
                this.txtNombre.Text = this.PersonaActual.Nombre;
                this.txtApellido.Text = this.PersonaActual.Apellido;
                this.txtDireccion.Text = this.PersonaActual.Direccion;
                this.txtEmail.Text = this.PersonaActual.Email;
                this.txtTelefono.Text = this.PersonaActual.Telefono;
                this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
                this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
                this.txtTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
                this.txtIdPlan.Text = this.PersonaActual.IdPlan.ToString();
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtID.Text = this.PersonaActual.ID.ToString();
                this.txtNombre.Text = this.PersonaActual.Nombre;
                this.txtApellido.Text = this.PersonaActual.Apellido;
                this.txtDireccion.Text = this.PersonaActual.Direccion;
                this.txtEmail.Text = this.PersonaActual.Email;
                this.txtTelefono.Text = this.PersonaActual.Telefono;
                this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
                this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
                this.txtTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
                this.txtIdPlan.Text = this.PersonaActual.IdPlan.ToString();
            }


            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
                this.txtID.Text = this.PersonaActual.ID.ToString();
                this.txtNombre.Text = this.PersonaActual.Nombre;
                this.txtApellido.Text = this.PersonaActual.Apellido;
                this.txtDireccion.Text = this.PersonaActual.Direccion;
                this.txtEmail.Text = this.PersonaActual.Email;
                this.txtTelefono.Text = this.PersonaActual.Telefono;
                this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
                this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
                this.txtTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
                this.txtIdPlan.Text = this.PersonaActual.IdPlan.ToString();
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Persona p = new Persona();
                PersonaActual = p;
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                this.PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                this.PersonaActual.TipoPersona = Int32.Parse(this.txtTipoPersona.Text);
                this.PersonaActual.IdPlan = Int32.Parse(this.txtIdPlan.Text);
                this.PersonaActual.State = BusinessEntity.States.New;
            }

            else if (Modo == ModoForm.Modificacion)
            {
                this.txtID.Text = this.PersonaActual.ID.ToString();
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                this.PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                this.PersonaActual.TipoPersona = Int32.Parse(this.txtTipoPersona.Text);
                this.PersonaActual.IdPlan = Int32.Parse(this.txtIdPlan.Text);
                this.PersonaActual.State = BusinessEntity.States.Modified;
            }

            else if (Modo == ModoForm.Baja)
            {
                this.txtID.Text = this.PersonaActual.ID.ToString();
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                this.PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                this.PersonaActual.TipoPersona = Int32.Parse(this.txtTipoPersona.Text);
                this.PersonaActual.IdPlan = Int32.Parse(this.txtIdPlan.Text);
                this.PersonaActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic u = new PersonaLogic();
            u.Save(PersonaActual);
        }
        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text.Trim()))
            {
                this.Notificar("El nombre es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtApellido.Text.Trim()))
            {
                this.Notificar("El apellido es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtDireccion.Text.Trim()))
            {
                this.Notificar("La dirección es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (!Business.Logic.Validaciones.EsEmailValido(this.txtEmail.Text))
            {
                this.Notificar("El email ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
            {
                this.Notificar("El teléfono es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtFechaNacimiento.Text.Trim()))
            {
                this.Notificar("La fecha de nacimiento es invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtLegajo.Text.Trim()))
            {
                this.Notificar("El legajo es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtTipoPersona.Text.Trim()))
            {
                this.Notificar("El tipo de persona es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (string.IsNullOrEmpty(this.txtIdPlan.Text.Trim()))
            {
                this.Notificar("El id de plan es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
