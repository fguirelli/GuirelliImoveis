using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Infra
{
    public class Imovel
    {
        public Imovel() { }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public byte TipoImovel { get; set; }
        [Required]
        public byte TipoOperacao { get; set; }
        [Required]
        [StringLength(2000)]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        public int CidadeId { get; set; }

        [Required]
        public int QuantidadeQuartos { get; set; }
        [Required]
        public int QuantidadeSuites { get; set; }
        [Required]
        public int QuantidadeBanheiros { get; set; }
        [Required]
        public int QuantidadeVagasGaragem { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal AreaTotal { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal AreaUtil { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get;set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
