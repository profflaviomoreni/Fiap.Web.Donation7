using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;

namespace Fiap.Web.Donation7.Repository
{
    public class CategoriaRepository
    {


        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<CategoriaModel> FindAll()
        {
            // SELECT * FROM Categoria
            var categorias = _dataContext.Categorias.ToList() ?? new List<CategoriaModel>();
            return categorias;
        }

        public CategoriaModel FindById(int id)
        {
            var categoria = _dataContext.Categorias.Find(id);
            return categoria;
        }


        public List<CategoriaModel> FindByName(string nome)
        {
            return null;
        }



        public int Insert(CategoriaModel categoriaModel)
        {
            // INSERT INTO Categoria (NomeCategoria, Token) VALUES (categoriaModel.NomeCategoria, categoriaModel.Token)
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }

        public void Update(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            // var categoria = new CategoriaModel { CategoriaId = id };

            var categoria = FindById(id);
            _dataContext.Categorias.Remove(categoria);
            _dataContext.SaveChanges();
        }


    }
}
