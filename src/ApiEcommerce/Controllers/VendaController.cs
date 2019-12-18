using ApiEcommerce.Model;
using AutoMapper;
using Business;
using Core.Arquitetura;
using Microsoft.AspNetCore.Mvc;
using ModelData.Model;
using ModelData.ViewModel;
using System.Linq;
using Util;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : BaseApiController<Venda, VendaViewModel, FiltroVenda>
    {
        private readonly IVendaBusiness _vendaBusiness;

        public VendaController(
            IGenericRepository<Venda> repository, 
            IMapper mapper,
            IVendaBusiness vendaBusiness) : base(repository, mapper)
        {
            _vendaBusiness = vendaBusiness;
        }

        /// <summary>
        /// Criar uma venda de itens
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CadastroVendaViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest("Informação errada");

            var venda = _vendaBusiness.RegistrarVenda(viewModel);

            return Ok(utilMapeamento.PrepararRetorno(venda));
        }

        /// <summary>
        /// Obter todos os dados por categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Get([FromQuery] FiltroVenda paginacao)
        {
            var dados = repository.ObterTodos().Where(c => c.Status != (int)Enumeracao.ESituacao.Cancelado);

            if (paginacao.DataInicial.HasValue)
                dados = dados.Where(c => c.DataDeCriacao >= paginacao.DataInicial);

            if (paginacao.DataFinal.HasValue)
                dados = dados.Where(c => c.DataDeCriacao <= paginacao.DataFinal);

            dados = dados.OrderByDescending(d => d.DataDeCriacao);

            return Ok(utilMapeamento.PrepararRetorno(dados, paginacao));
        }
    }
}