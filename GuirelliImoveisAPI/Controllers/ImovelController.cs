using GuirelliImoveisAPI.DTO;
using Infra;
using Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace GuirelliImoveisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly ILogger<ImovelController> _logger;
        private readonly ApplicationDbContext _db;

        public ImovelController(ILogger<ImovelController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [Route("api/Imoveis", Name = "GetImoveis")]
        public List<ImovelDTO> GetImoveis()
        {
            List<Imovel> listaImoveis = new List<Imovel>();
            listaImoveis = _db.Imoveis.ToList();

            var objImoveisDTO = new List<ImovelDTO>();

            foreach (Imovel imovel in listaImoveis)
            {
                ImovelDTO _imovel = new ImovelDTO();
                _imovel.Id = imovel.Id;
                _imovel.Titulo = imovel.Titulo;
                _imovel.Descricao = imovel.Descricao;
                _imovel.AreaTotal = imovel.AreaTotal;
                _imovel.AreaUtil = imovel.AreaUtil;
                _imovel.QuantidadeQuartos = imovel.QuantidadeQuartos;
                _imovel.QuantidadeBanheiros = imovel.QuantidadeBanheiros;
                _imovel.QuantidadeSuites = imovel.QuantidadeSuites;
                _imovel.QuantidadeVagasGaragem = imovel.QuantidadeVagasGaragem;
                _imovel.CidadeId = imovel.CidadeId;
                _imovel.TipoImovel = imovel.TipoImovel;
                _imovel.TipoOperacao = imovel.TipoOperacao;
                _imovel.Preco = imovel.Preco;
                _imovel.DataCadastro = imovel.DataCadastro;

                objImoveisDTO.Add(_imovel);
            }

            return objImoveisDTO;
        }

        [HttpGet]
        [Route("api/Imoveis/{id}", Name = "GetImoveisById")]
        public ImovelDTO GetImoveisById(int id)
        {
            Imovel imovel = (Imovel)_db.Imoveis.Where(x=> x.Id == id).ToList()[0];
            ImovelDTO _imovel = new ImovelDTO();
            _imovel.Titulo = imovel.Titulo;
            _imovel.Descricao = imovel.Descricao;
            _imovel.AreaTotal = imovel.AreaTotal;
            _imovel.AreaUtil = imovel.AreaUtil;
            _imovel.QuantidadeQuartos = imovel.QuantidadeQuartos;
            _imovel.QuantidadeBanheiros = imovel.QuantidadeBanheiros;
            _imovel.QuantidadeSuites = imovel.QuantidadeSuites;
            _imovel.QuantidadeVagasGaragem = imovel.QuantidadeVagasGaragem;
            _imovel.CidadeId = imovel.CidadeId;
            _imovel.TipoImovel = imovel.TipoImovel;
            _imovel.TipoOperacao = imovel.TipoOperacao;
            _imovel.Preco = imovel.Preco;
            _imovel.DataCadastro = imovel.DataCadastro;

            return _imovel;
        }

        [HttpPost]
        [Route("api/Imoveis", Name = "AddImovel")]
        public int? AddImovel(ImovelDTO imovel)
        {
            Imovel _imovel = new Imovel();
            _imovel.Titulo = imovel.Titulo;
            _imovel.Descricao = imovel.Descricao;
            _imovel.AreaTotal = imovel.AreaTotal;
            _imovel.AreaUtil = imovel.AreaUtil;
            _imovel.QuantidadeQuartos = imovel.QuantidadeQuartos;
            _imovel.QuantidadeBanheiros = imovel.QuantidadeBanheiros;
            _imovel.QuantidadeSuites = imovel.QuantidadeSuites;
            _imovel.QuantidadeVagasGaragem = imovel.QuantidadeVagasGaragem;
            _imovel.CidadeId = imovel.CidadeId;
            _imovel.TipoImovel = imovel.TipoImovel;
            _imovel.TipoOperacao = imovel.TipoOperacao;
            _imovel.Preco = imovel.Preco;
            _imovel.DataCadastro = imovel.DataCadastro;

            _db.Imoveis.Add(_imovel);
            _db.SaveChanges();
            return _imovel.Id;
        }

        [HttpPost]
        [Route("api/ImovelImagens", Name = "AddImovelImagem")]
        public ImovelImagemDTO AddImovelImagem(ImovelImagemDTO imovelImagem)
        {
            ImovelImagem _imovelImagem = new ImovelImagem();
            _imovelImagem.NumeroImagem = imovelImagem.NumeroImagem;
            _imovelImagem.CaminhoImagem = imovelImagem.CaminhoImagem;
            _imovelImagem.ImovelId = imovelImagem.ImovelId;

            _db.ImovelImagens.Add(_imovelImagem);
            _db.SaveChanges();
            return imovelImagem;
        }

        [HttpGet]
        [Route("api/ImovelImagens/{id}", Name = "GetImovelImagens")]
        public List<ImovelImagemDTO> GetImovelImagens(int id)
        {
            List<ImovelImagem> imovelImagens = (List<ImovelImagem>)_db.ImovelImagens.Where(x => x.ImovelId == id).ToList();
            List<ImovelImagemDTO> _imovelImagens = new List<ImovelImagemDTO>();

            foreach (ImovelImagem imovelImagem in imovelImagens)
            {
                ImovelImagemDTO _imovelImagem = new ImovelImagemDTO();
                _imovelImagem.NumeroImagem = imovelImagem.NumeroImagem;
                _imovelImagem.CaminhoImagem = imovelImagem.CaminhoImagem;
                _imovelImagem.ImovelId = imovelImagem.ImovelId;

                _imovelImagens.Add(_imovelImagem);
            }

            return _imovelImagens;
        }

        [HttpGet]
        [Route("api/Cidades", Name = "GetCidades")]
        public List<CidadeDTO> GetCidades()
        {
            List<Cidade> cidades = (List<Cidade>)_db.Cidades.ToList();
            List<CidadeDTO> _cidades = new List<CidadeDTO>();

            foreach (Cidade cidade in cidades)
            {
                CidadeDTO _cidade = new CidadeDTO();
                _cidade.Id = cidade.Id;
                _cidade.Nome = cidade.Nome;

                _cidades.Add(_cidade);
            }

            return _cidades;
        }
    }
}