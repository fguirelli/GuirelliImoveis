using GuirelliImoveis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using GuirelliImoveisAPI.DTO;
using System.Collections.Generic;
using System.Dynamic;
using Infra;
using System.Text;

namespace GuirelliImoveis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            dynamic viewModel = new ExpandoObject();
            viewModel.Imoveis = this.ObterImoveis().Result;

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            ViewBag.TipoOperacao = Util.ObterTiposOperacao();
            ViewBag.TipoImovel = Util.ObterTiposImovel();
            ViewBag.Cidades = Util.ObterCidades().Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Imovel obj, List<IFormFile> uploadFiles)
        {
            int? imovelId = this.CriarImovel(obj).Result;
            if(uploadFiles.Count > 0)
            {
                int count = 1;
                foreach (IFormFile file in uploadFiles)
                {
                    if (imovelId.HasValue)
                    {
                        this.SalvarImagem(imovelId.Value, file, count);
                    }
                    count++;
                }
            }
            return RedirectToAction("Index");
        }

        public async void SalvarImagem(int imovelId, IFormFile arquivo, int numeroImagem)
        {
            var ApiURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["GuirelliImoveisAPIUrl"];
            ImovelImagemDTO _imovelImagem = new ImovelImagemDTO();
            
            string fileName = imovelId.ToString() + "_" + numeroImagem.ToString() + ".jpg";
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//UserFile", fileName);

            _imovelImagem.ImovelId = imovelId;
            _imovelImagem.NumeroImagem = numeroImagem;
            _imovelImagem.CaminhoImagem = uploadPath;

            var conteudo = JsonConvert.SerializeObject(_imovelImagem);
            var conteudoString = new StringContent(conteudo, Encoding.UTF8, "application/json");
            string apiResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(ApiURL + "ImovelImagens", conteudoString))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            var stream = new FileStream(uploadPath, FileMode.Create);
            //arquivo.CopyToAsync(stream);
        }

        public async Task<int?> CriarImovel(Imovel imovel)
        {
            var ApiURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["GuirelliImoveisAPIUrl"];
            ImovelDTO _imovel = new ImovelDTO();

            _imovel.Titulo = imovel.Titulo;
            _imovel.Descricao = imovel.Descricao;
            _imovel.CidadeId = int.Parse(Request.Form["ddlCidade"].ToString());
            _imovel.QuantidadeQuartos = imovel.QuantidadeQuartos;
            _imovel.QuantidadeBanheiros = imovel.QuantidadeBanheiros;
            _imovel.QuantidadeSuites = imovel.QuantidadeSuites;
            _imovel.DataCadastro = DateTime.Now;
            _imovel.Preco = imovel.Preco;
            _imovel.AreaTotal = imovel.AreaTotal;
            _imovel.AreaUtil = imovel.AreaUtil;
            _imovel.QuantidadeVagasGaragem = imovel.QuantidadeVagasGaragem;
            _imovel.TipoOperacao = byte.Parse(Request.Form["ddlTipoOperacao"].ToString());
            _imovel.TipoImovel = byte.Parse(Request.Form["ddlTipoImovel"].ToString());

            var conteudo = JsonConvert.SerializeObject(_imovel);
            var conteudoString = new StringContent(conteudo, Encoding.UTF8, "application/json");
            string apiResponse = string.Empty;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(ApiURL + "Imoveis", conteudoString))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            var imovelId = JsonConvert.DeserializeObject<int?>(apiResponse);

            return imovelId;
        }

        public async Task<List<ImovelDTO>> ObterImoveis()
        {
            var ApiURL = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["GuirelliImoveisAPIUrl"];

            List<ImovelDTO>? imoveisList = new List<ImovelDTO>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiURL + "Imoveis"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    imoveisList = JsonConvert.DeserializeObject<List<ImovelDTO>>(apiResponse);
                }
            }

            return imoveisList == null ? new List<ImovelDTO>() : imoveisList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}