using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic:BusinessLogic 
    {
        public AlumnoInscripcionLogic()
        {
            this.AlumnoInscripcionData = new Data.Database.AlumnoInscripcionAdapter();
        }

        public Data.Database.AlumnoInscripcionAdapter AlumnoInscripcionData
        {
            get;
            set;
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return (AlumnoInscripcionData.GetAll());
        }

        public Business.Entities.AlumnoInscripcion GetOne(int id)
        {
            return (AlumnoInscripcionData.GetOne(id));
        }

        public void Delete(int id)
        {
            AlumnoInscripcionData.Delete(id);
        }

        public void Save(Business.Entities.AlumnoInscripcion a)
        {
            AlumnoInscripcionData.Save(a);
        }
    }
}
