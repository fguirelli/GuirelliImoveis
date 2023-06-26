using GuirelliImoveisAPI.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace GuirelliImoveis
{
    public static class Util
    {
        public async static Task<string> ObterCidade(int id)
        {
            var ApiURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["GuirelliImoveisAPIUrl"];

            List<CidadeDTO>? cidadeList = new List<CidadeDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiURL + "Cidades"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cidadeList = JsonConvert.DeserializeObject<List<CidadeDTO>>(apiResponse);
                }
            }

            string? cidade = ((CidadeDTO?)cidadeList?.FirstOrDefault(x => x.Id == id))?.Nome;
            return cidade == null ? string.Empty : cidade;
        }

        public async static Task<List<CidadeDTO>> ObterCidades()
        {
            var ApiURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["GuirelliImoveisAPIUrl"];

            List<CidadeDTO>? cidadeList = new List<CidadeDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiURL + "Cidades"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cidadeList = JsonConvert.DeserializeObject<List<CidadeDTO>>(apiResponse);
                }
            }

            return cidadeList == null ? new List<CidadeDTO>() : cidadeList;
        }

        public static string ObterTipoImovel(int id)
        {
            switch (id)
            {
                case 1: return "Casa Condomínio";
                case 2: return "Casa";
                case 3: return "Sobrado";
                case 4: return "Apartamento";
                case 5: return "Comercial";
                case 6: return "Terreno";
                case 7: return "Terreno em Condomínio";
                case 8: return "Chácara";
                default: return string.Empty;
            }
        }

        public static SelectList ObterTiposOperacao()
        {
            var enumData = from Dominio.TipoOperacao e in Enum.GetValues(typeof(Dominio.TipoOperacao))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };

            SelectList lista = new SelectList(enumData, "ID", "Name");
            return lista;
        }

        public static SelectList ObterTiposImovel()
        {
            var enumData = from Dominio.TipoImovel e in Enum.GetValues(typeof(Dominio.TipoImovel))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };

            SelectList lista = new SelectList(enumData, "ID", "Name");
            return lista;
        }

        public static async Task<List<ImovelImagemDTO>> ObterImoveisImagens(int imovelId)
        {
            var ApiURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["GuirelliImoveisAPIUrl"];

            List<ImovelImagemDTO>? imoveisImagensList = new List<ImovelImagemDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiURL + "ImovelImagens/" + imovelId.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    imoveisImagensList = JsonConvert.DeserializeObject<List<ImovelImagemDTO>>(apiResponse);
                }
            }

            return imoveisImagensList == null ? new List<ImovelImagemDTO>() : imoveisImagensList;
        }

        public static string ObterTipoOperacao(int id)
        {
            switch (id)
            {
                case 1: return "Venda";
                case 2: return "Aluguel";
                default: return string.Empty;
            }
        }

        public static string FormatarValorMonetario(decimal valor)
        {
            return valor.ToString("C");
        }
    }
}
