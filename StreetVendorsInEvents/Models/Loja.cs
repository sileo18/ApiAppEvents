using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class Loja
    {
        [Key]
        public int Id { get; set; } // Chave primária

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }          
        public ICollection<Opcoes> Cardapio { get; set; } = new List<Opcoes>();

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        //FK Evento
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public Loja() { }

        public Loja(string nome)
        {
            Nome = nome;
        }

    }
}
