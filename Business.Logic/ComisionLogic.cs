using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic:BusinessLogic
    {
        public ComisionLogic()
        {
            this.ComisionData = new Data.Database.ComisionAdapter();
        }

        public Data.Database.ComisionAdapter ComisionData
        {
            get;
            set;
        }

        public List<Comision> GetAll()
        {
            return (ComisionData.GetAll());
        }

        public Business.Entities.Comision GetOne(int id)
        {
            return (ComisionData.GetOne(id));
        }

        public void Delete(int id)
        {
            ComisionData.Delete(id);
        }

        public void Save(Business.Entities.Comision u)
        {
            ComisionData.Save(u);
        }
    }
}
