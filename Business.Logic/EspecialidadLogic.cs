using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadLogic()
        {
            this.EspecialidadData = new Data.Database.EspecilidadAdapter();
        }

        public Data.Database.EspecilidadAdapter EspecialidadData
        {
            get;
            set;
        }

        public List<Especialidad> GetAll()
        {
            return (EspecialidadData.GetAll());
        }

        public Business.Entities.Especialidad GetOne(int id)
        {
            return (EspecialidadData.GetOne(id));
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id); 
        }

        public void Save(Business.Entities.Especialidad e)
        {
            EspecialidadData.Save(e); 
        }

    }
}
