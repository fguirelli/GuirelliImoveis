using Infra;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GuirelliImoveisAPI.DTO
{
    public class ImovelDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public byte TipoImovel { get; set; }
        public byte TipoOperacao { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int CidadeId { get; set; }
        public int QuantidadeQuartos { get; set; }
        public int QuantidadeSuites { get; set; }
        public int QuantidadeBanheiros { get; set; }
        public int QuantidadeVagasGaragem { get; set; }
        public decimal AreaTotal { get; set; }
        public decimal AreaUtil { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
