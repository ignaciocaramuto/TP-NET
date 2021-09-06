using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        public PersonaLogic()
        {
            this.PersonaData = new Data.Database.PersonaAdapter();
        }

        public Data.Database.PersonaAdapter PersonaData
        {
            get;
            set;
        }

        public List<Persona> GetAll()
        {
            return (PersonaData.GetAll());
        }

        public Business.Entities.Persona GetOne(int id)
        {
            return (PersonaData.GetOne(id));
        }

        public void Delete(int id)
        {
            PersonaData.Delete(id);
        }

        public void Save(Business.Entities.Persona u)
        {
            PersonaData.Save(u);
        }
    }
}
