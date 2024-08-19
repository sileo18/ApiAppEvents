using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class Opcoes
    {
        [Key]
        public int Id { get; set; } // Chave primária

        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        // Chave estrangeira
        public int LojaId { get; set; }
        public Loja Loja { get; set; }

        public ICollection<OpcoesPedidos> OpcaoPedidos { get; set; } = new List<OpcoesPedidos>();

        public Opcoes(string descricao, decimal preco, int lojaId, Loja loja)
        {
            Descricao = descricao;
            Preco = preco;
            LojaId = lojaId;
            Loja = loja;
        }

        public Opcoes() { }
    }
}
