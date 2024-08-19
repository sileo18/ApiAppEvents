using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public User(string nome, Endereco endereco)
        {
            Nome = nome;
          
        }

        public User() { }

    }
}
