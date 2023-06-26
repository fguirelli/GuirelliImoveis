using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra
{
    public class ImovelImagem
    {
        public ImovelImagem() { }

        public int ImovelId { get; set; }
        public int NumeroImagem { get; set; }
        [Required]
        [StringLength(1000)]
        public string CaminhoImagem { get; set; } = string.Empty;
        public Imovel Imovel { get; set; }
    }
}
