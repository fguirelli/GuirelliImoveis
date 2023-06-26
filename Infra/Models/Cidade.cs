using System.ComponentModel.DataAnnotations;

namespace Infra
{
    public class Cidade
    {
        public Cidade() { }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
    }
}
