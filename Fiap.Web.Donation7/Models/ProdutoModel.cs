using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation7.Models
{
    [Table("Produtos")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(80)]
        public string NomeProduto { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é requerido")]
        [StringLength(150)]
        public string Descricao { get; set; }

        [Display(Name = "Sugestão de Troca")]
        [Required(ErrorMessage = "A sugestão de troca é obrigatória")]
        [StringLength(100)]
        public string SugestaoTroca { get; set; }

        [Display(Name = "Disponível")]
        public bool Disponivel { get; set; }

        [Display(Name = "Valor do Produto")]
        [Required(ErrorMessage = "O valor do produto é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(minimum: 10, maximum: 30000, ErrorMessage = "O valor do produto deve ser um valor entre 10 e 30000.")]
        public double? Valor { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Display(Name = "Data de Expiração")]
        [Required(ErrorMessage = "A data de expiração é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime? DataExpiracao { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public int? CategoriaId { get; set; } // FK CategoriaModel.CategoriaId
        
        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel? Categoria { get; set; } // Propriedade de navegação para CategoriaModel

        [Display(Name = "Id do Usuário")]
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public int? UsuarioId { get; set; } // FK UsuarioModel.UsuarioId
        
        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel? Usuario { get; set; } // Propriedade de navegação para UsuarioModel

    }
}
