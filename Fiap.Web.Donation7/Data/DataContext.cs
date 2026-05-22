
using Fiap.Web.Donation7.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation7.Data
{
    public class DataContext : DbContext
    {

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
