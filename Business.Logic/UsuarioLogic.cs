using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {

        private UsuarioAdapter _usuarioData;
        
        public UsuarioLogic()
        {
            this.UsuarioData = new Data.Database.UsuarioAdapter();
        }
        
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _usuarioData; }
            set { _usuarioData = value; }
        }

        public List<Usuario> GetAll()
        {
            return (UsuarioData.GetAll());
        }

        public Business.Entities.Usuario GetOne(int id)
        {
            return (UsuarioData.GetOne(id));
        }

        public bool Existe(string nomUsu)
        {
            return _usuarioData.ExisteUsuario(nomUsu);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public void Save(Business.Entities.Usuario u)
        {
            UsuarioData.Save(u);
        }

        public Usuario GetUsuarioForLogin (string user, string pass)
        {
            return UsuarioData.GetUsuarioForLogin(user, pass);
        }
    }
}
