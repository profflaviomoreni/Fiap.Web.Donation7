using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation7.Repository
{
    public class UsuarioRepository
    {


        private readonly DataContext _dataContext;
        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<UsuarioModel> FindAll()
        {
            // SELECT * FROM Usuario
            var usuarios = _dataContext.Usuarios.AsNoTracking().ToList() ?? new List<UsuarioModel>();
            return usuarios;
        }

        public UsuarioModel FindById(int id)
        {
            var usuario = _dataContext.Usuarios.AsNoTracking().FirstOrDefault(u => u.UsuarioId == id);
            return usuario;
        }


        public UsuarioModel FindByEmailAndSenha(string email, string senha)
        {
            var usuario = _dataContext.Usuarios.AsNoTracking()
                                .FirstOrDefault(u => 
                                    u.Email == email && 
                                    u.Senha == senha);
            return usuario;
        }


        public List<UsuarioModel> FindByName(string nome)
        {
            return null;
        }



        public int Insert(UsuarioModel usuarioModel)
        {
            // INSERT INTO Usuario (Nome, Email, Senha, Regra) VALUES (...)
            _dataContext.Usuarios.Add(usuarioModel);
            _dataContext.SaveChanges();

            return usuarioModel.UsuarioId;
        }

        public void Update(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Update(usuarioModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            // var usuario = new UsuarioModel { UsuarioId = id };

            var usuario = FindById(id);
            _dataContext.Usuarios.Remove(usuario);
            _dataContext.SaveChanges();
        }


    }
}
