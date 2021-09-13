using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic:BusinessLogic
    {
        public DocenteCursoLogic()
        {
            this.DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }

        public Data.Database.DocenteCursoAdapter DocenteCursoData
        {
            get;
            set;
        }

        public List<DocenteCurso> GetAll()
        {
            return (DocenteCursoData.GetAll());
        }

        public Business.Entities.DocenteCurso GetOne(int id)
        {
            return (DocenteCursoData.GetOne(id));
        }

        public void Delete(int id)
        {
            DocenteCursoData.Delete(id);
        }

        public void Save(Business.Entities.DocenteCurso dc)
        {
            DocenteCursoData.Save(dc);
        }

    }
}

