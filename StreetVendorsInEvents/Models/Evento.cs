using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }       
       
        public Categoria Categoria { get; set; }

        public ICollection<Loja> Lojas { get; set; } = new List<Loja>();

        public int EnderecoId { get; set; } // FK para Endereco
        public Endereco Endereco { get; set; } // Navegação para Endereco  

        public Evento(string nome, Categoria categoria)
        {
            Nome = nome;            
            Categoria = categoria;
        }

        public Evento() { }
    }

    public enum Categoria
    {
        Cultural,
        Gastronômico,
        Esportivo,
        Empresarial,
        Músicas,
        Jogos,
        Luta,
        Educação
    }

   
}
