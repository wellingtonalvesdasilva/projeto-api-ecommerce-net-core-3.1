using ApiEcommerce.Helper;
using ApiEcommerce.Model;
using AutoMapper;
using Core.Arquitetura;
using Microsoft.AspNetCore.Mvc;
using ModelData.Model;
using System.Linq;
using Util;

namespace ApiEcommerce.Controllers
{
    /// <summary>
    /// Classe base para todas as APIs da aplicação
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    public class BaseApiController<TModel, TViewModel, TFilter> : ControllerBase
        where TModel : BaseEntity
        where TViewModel : class
        where TFilter : ParametroDePaginacao
    {
        /// <summary>
        /// Repositório dinâmico de acordo com o modelo de dados
        /// </summary>
        public readonly IGenericRepository<TModel> repository;
        private readonly IMapper _mapper;
        public readonly UtilMapeamento<TViewModel, TModel, TFilter> utilMapeamento;

        /// <summary>
        /// Construtor da BaseAPI que será utilizado por todas as APIs
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public BaseApiController(IGenericRepository<TModel> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
            utilMapeamento = new UtilMapeamento<TViewModel, TModel, TFilter>(_mapper);
        }

        /// <summary>
        /// Obter todos os dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get([FromQuery] TFilter paginacao)
        {
            var todosAtivos = repository.ObterTodos().Where(c => c.Status != (int)Enumeracao.ESituacao.Cancelado);
            return Ok(utilMapeamento.PrepararRetorno(todosAtivos, paginacao));
        }

        /// <summary>
        /// Obter o dado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var data = repository.ObterPorID(id);

            if (data == null)
                return NotFound("Informação não localizada");

            return Ok(utilMapeamento.PrepararRetorno(data));
        }
    }
}
