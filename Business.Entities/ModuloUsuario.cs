using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario:BusinessEntity
    {
        private int _idUsuario;
        private bool _permiteAlta;
        private bool _permiteBaja;
        private bool _permiteModificacion;
        private bool _permiteConsulta;
        private Modulo _modulo;

        public ModuloUsuario()
        {
            this.Modulo = new Modulo();
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdModulo
        {
            get { return this.Modulo.ID; }
        }

        public Modulo Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        public bool PermiteAlta
        {
            get { return _permiteAlta; }
            set { _permiteAlta = value; }
        }

        public bool PermiteBaja
        {
            get { return _permiteBaja; }
            set { _permiteBaja = value; }
        }

        public bool PermiteModificacion
        {
            get { return _permiteModificacion; }
            set { _permiteModificacion = value; }
        }

        public bool PermiteConsulta
        {
            get { return _permiteConsulta; }
            set { _permiteConsulta = value; }
        }

        public string DescModulo
        {
            get { return this.Modulo.Descripcion; }
        }
    }
}
