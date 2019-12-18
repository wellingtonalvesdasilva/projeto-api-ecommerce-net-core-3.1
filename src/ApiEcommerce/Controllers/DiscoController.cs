using ApiEcommerce.Model;
using AutoMapper;
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
    public class DiscoController : BaseApiController<Disco, DiscoViewModel, FiltroDisco>
    {
        public DiscoController(IGenericRepository<Disco> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        /// <summary>
        /// Obter todos os dados por categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public override IActionResult Get([FromQuery] FiltroDisco paginacao)
        {
            var dados = repository.ObterTodos().Where(c => c.Status != (int)Enumeracao.ESituacao.Cancelado);

            if (paginacao.CategoriaId.HasValue)
                dados = dados.Where(c => c.Categoria_Id == paginacao.CategoriaId);

            dados = dados.OrderBy(d => d.Nome);

            return Ok(utilMapeamento.PrepararRetorno(dados, paginacao));
        }
    }
}