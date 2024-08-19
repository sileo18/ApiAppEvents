using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class OpcoesPedidos
    {
        [Key]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        [Key]
        public int OpcaoId { get; set; }
        public Opcoes Opcao { get; set; }

        public int Quantidade { get; set; } 

    }
}
