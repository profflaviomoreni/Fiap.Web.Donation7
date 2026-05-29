using Fiap.Web.Donation7.Data;
using Fiap.Web.Donation7.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation7.Repository
{
    public class ProdutoRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<ProdutoModel> FindAll()
        {

            return _dataContext.Produtos.AsNoTracking().ToList() ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllWithCategorias()
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Include(c => c.Categoria)  // Inner Join com a tabela Categoria
                            .ToList();

            return produtos ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllWithCategoriasAndUsuarios()
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Include(c => c.Categoria) // Inner Join com a tabela Categoria
                                .Include(u => u.Usuario)   // Inner Join com a tabela Usuario
                            .ToList();

            return produtos ?? new List<ProdutoModel>();
        }


        public List<ProdutoModel> FindAllWithCategoriasAndUsuariosByName(string nome)
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where(p =>
                                    p.NomeProduto.ToLower().Contains(nome.ToLower()) // Like '%nome%' 
                                    //p.NomeProduto.ToLower().StartsWith(nome.ToLower()) // Like 'nome%' 
                                    //p.NomeProduto.ToLower().EndsWith(nome.ToLower()) // Like '%nome'
                                    //p.NomeProduto.ToLower() == nome.ToLower()
                                )  
                                .Include(c => c.Categoria) 
                                .Include(u => u.Usuario)   
                            .ToList();

            return produtos ?? new List<ProdutoModel>();
        }


        public List<ProdutoModel> FindAllAvailableWithCategoriasAndUsuarios()
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where(p =>
                                     p.Disponivel == true &&
                                     p.DataExpiracao >= DateTime.UtcNow
                                )
                                .Include(c => c.Categoria) 
                                .Include(u => u.Usuario)   
                            .ToList();

            return produtos ?? new List<ProdutoModel>();
        }


        // SEU
        public List<ProdutoModel> FindAllAvailablesWithCategoriaAndUsuarioByUserId(int userId)
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where(p =>
                                    p.Disponivel == true &&
                                    p.DataExpiracao >= DateTime.UtcNow &&
                                    p.UsuarioId == userId
                                )
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }


        // NAO é SEU
        public List<ProdutoModel> FindAllAvailablesForChangeWithCategoriaAndUsuario(int userId)
        {
            var produtos = _dataContext.Produtos.AsNoTracking()
                                .Where(p =>
                                    p.Disponivel == true &&
                                    p.DataExpiracao >= DateTime.UtcNow &&
                                    p.UsuarioId != userId
                                )
                                .Include(c => c.Categoria) // INNER JOIN                                   
                                .Include(u => u.Usuario)   // INNER JOIN 
                                .ToList();

            return produtos ?? new List<ProdutoModel>();
        }



        public ProdutoModel FindById(int id)
        {
            return _dataContext.Produtos.AsNoTracking()
                        .Include(c => c.Categoria) // Inner Join com a tabela Categoria
                        .Include(u => u.Usuario)   // Inner Join com a tabela Usuario
                        .SingleOrDefault( p => p.ProdutoId == id); // Where ProdutoId = id
        }


        public int Insert(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Add(ProdutoModel);
            _dataContext.SaveChanges();

            return ProdutoModel.ProdutoId;
        }


        public void Update(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Update(ProdutoModel);
            _dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var Produto = FindById(id);

            _dataContext.Produtos.Remove(Produto);
            _dataContext.SaveChanges();

        }

    }
}
