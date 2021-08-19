using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic:BusinessLogic
    {
        public PlanLogic()
        {
            this.PlanData = new Data.Database.PlanAdapter();
        }

        public Data.Database.PlanAdapter PlanData
        {
            get;
            set;
        }

        public List<Plan> GetAll()
        {
            return (PlanData.GetAll());
        }

        public Business.Entities.Plan GetOne(int id)
        {
            return (PlanData.GetOne(id));
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }

        public void Save(Business.Entities.Plan u)
        {
            PlanData.Save(u);
        }
    }
}
