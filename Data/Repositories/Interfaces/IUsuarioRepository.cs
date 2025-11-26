using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.Identity.Client;

namespace Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Get(Guid id);
        Usuario Get(string userName,string email);
        bool Any(string userName, string email);
        List<Usuario> GetAll();
        Guid Insert(Usuario usuario);
        void InsertRange(List<Usuario> usuarios);
        void Update(Usuario usuario);
        void Delete(Guid id);
        Usuario Login(string username, string contrasena);
    }
}
