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
        List<Usuario> GetAll();
        void Insert(Usuario usuario);
        void InsertRange(List<Usuario> usuarios);
        void Update(Usuario usuario);
        void Delete(Guid id);
    }
}
