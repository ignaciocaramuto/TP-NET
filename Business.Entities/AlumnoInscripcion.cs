using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        private string _condicion;
        private int _idAlumno;
        private int _idCurso;
        private int _nota;
        private Persona _alumno;
        private Curso _curso;

        public AlumnoInscripcion()
        {
            this._alumno = new Persona();
            this._curso = new Curso();
        }

        public string Condicion
        {
            get { return _condicion; }
            set { _condicion = value; }
        }

        public Persona Alumno
        {
            get { return _alumno; }
            set { _alumno = value; }

        }

        public Curso Curso
        {
            get { return _curso; }
            set { _curso = value; }
        }

        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }

        public string DescComision
        {
            get { return Curso.Comision.Descripcion; }
        }

        public string DescMateria
        {
            get { return Curso.Materia.Descripcion; }
        }

        public int AnioCurso
        {
            get { return Curso.AnioCalendario; }
        }

        public string Apellido
        {
            get { return this.Alumno.Apellido; }
        }

        public string Nombre
        {
            get { return this.Alumno.Nombre; }
        }
    }
}
