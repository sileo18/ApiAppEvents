using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; } // ID único para cada pedido         
        public ICollection<OpcoesPedidos> OpcaoPedidos { get; set; } = new List<OpcoesPedidos>();

        public int LojaId { get; set; }
        public Loja Loja { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Pedido(Loja loja, List<Opcoes> opcoes, User user)
        {
            Loja = loja;
            User = user;
            OpcaoPedidos = new List<OpcoesPedidos>(); // Inicializar OpcaoPedidos
        }

        public Pedido() { }


    }
}
