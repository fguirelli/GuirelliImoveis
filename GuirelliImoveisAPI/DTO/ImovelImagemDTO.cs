using Infra;
using System.ComponentModel.DataAnnotations;

namespace GuirelliImoveisAPI.DTO
{
    public class ImovelImagemDTO
    {
        public int ImovelId { get; set; }
        public int NumeroImagem { get; set; }
        public string CaminhoImagem { get; set; } = string.Empty;
    }
}
