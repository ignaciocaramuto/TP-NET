﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic
    {
        public Data.Database.MateriaAdapter MateriaData
        {
            get;
            set;
        }

        public MateriaLogic()
        {
            this.MateriaData = new Data.Database.MateriaAdapter();
        }


        public List<Materia> GetAll()
        {
            return (MateriaData.GetAll());
        }

        public Business.Entities.Materia GetOne(int id)
        {
            return (MateriaData.GetOne(id));
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

        public void Save(Business.Entities.Materia m)
        {
            MateriaData.Save(m);
        }
    }
}