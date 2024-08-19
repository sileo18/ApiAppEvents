using System.ComponentModel.DataAnnotations;

namespace StreetVendorsInEvents.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Rua { get; set; }


        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }


        [Required]
        [StringLength(100)]
        public string Estado { get; set; }

        [Required]
        [StringLength(10)]
        public string Cep { get; set; }

        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
