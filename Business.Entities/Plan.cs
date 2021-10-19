using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan:BusinessEntity
    {
        private string _descripcion;
        private int _idEspecialidad;
        private Especialidad _especialidad;

        public Plan()
        {
            this.Especialidad = new Especialidad();
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int IdEspecialidad
        {
            get { return _idEspecialidad; }
            set { _idEspecialidad = value; }
        }

        public Especialidad Especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }

        public string DescEspecialidad
        {
            get { return this.Especialidad.Descripcion; }
        }
    }
}
