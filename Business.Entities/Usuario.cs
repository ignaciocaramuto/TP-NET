using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario:BusinessEntity
    {
        private string _nombreUsuario;
        private string _clave;
        private bool _habilitado;
        private Persona _persona;
        private List<ModuloUsuario> _modulosUsuarios;
        
        public Usuario()
        {
            this._persona = new Persona();
            this._modulosUsuarios = new List<ModuloUsuario>();
        }
        
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public string Nombre
        {
            get { return this.Persona.Nombre; }
        }

        public string Apellido
        {
            get { return this.Persona.Apellido; }
        }

        public string EMail
        {
            get { return this.Persona.Email; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        public Persona Persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public List<ModuloUsuario> ModulosUsuarios
        {
            get { return _modulosUsuarios; }
            set { _modulosUsuarios = value; }
        }

        public string TipoPersona
        {
            get { return this.Persona.DescTipoPersona; }
        }


    }
}
