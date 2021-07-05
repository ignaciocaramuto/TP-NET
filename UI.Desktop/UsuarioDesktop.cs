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
    public partial class UsuarioDesktop : ApplicationForm
    {
        
        public UsuarioDesktop()
        { 
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this() {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Usuario UsuarioActual{

            get;
            set;
        }

        public override void MapearDeDatos() { }
        public override void MapearADatos() { }
        public override void GuardarCambios() { }
        public override bool Validar() { return false; }
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
