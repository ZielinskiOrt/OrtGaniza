using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Entities.Entities;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {


        private readonly OrtganizaDbContext _db;
        public UsuarioRepository(OrtganizaDbContext db)
        {
            _db = db;
        }
        public void Delete(Guid id)
        {
            _db.Remove(id);
        }

        public Usuario Get(Guid id)
        {
            return _db.Usuarios.Find(id);
        }

        public List<Usuario> GetAll()
        {
            return _db.Usuarios.ToList();
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                _db.Usuarios.Add(usuario);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                //despues poner logs
            }
        }
        public void InsertRange(List<Usuario> usuarios)
        {
            try
            {
                _db.Usuarios.AddRange(usuarios);
            }
            catch (Exception ex)
            {
                //despues poner logs
            }
        }

        public void Update(Usuario usuario)
        {
            _db.Update(usuario);
        }
    }
}
