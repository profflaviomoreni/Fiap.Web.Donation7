using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation7.Models
{

    [Table("Categorias")]
    [Index(nameof(NomeCategoria), IsUnique = true)]
    public class CategoriaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CategoriaId")]
        public int CategoriaId { get; set; }

        [Column("NomeCategoria")]
        [Required]
        [StringLength(80)]
        public string NomeCategoria { get; set; }

        [NotMapped]
        public string? Token { get; set; }

    }
}