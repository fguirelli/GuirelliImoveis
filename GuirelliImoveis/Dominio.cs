using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GuirelliImoveis
{
    public static class Dominio
    {
        public enum TipoOperacao
        {
            Venda = 1,
            Aluguel = 2
        };

        public enum TipoImovel
        {
            [Display(Name = "Casa em Condomínio")]
            CasaCondominio = 1,
            [Display(Name = "Casa")]
            Casa = 2,
            [Display(Name = "Sobrado")]
            Sobrado = 3,
            [Display(Name = "Apartamento")]
            Apartamento = 4,
            [Display(Name = "Comercial")]
            Comercial = 5,
            [Display(Name = "Terreno")]
            Terreno = 6,
            [Display(Name = "Terreno em Condomínio")]
            TerrenoCondominio = 7,
            [Display(Name = "Chácara")]
            Chacara = 8
        };
    }
}
