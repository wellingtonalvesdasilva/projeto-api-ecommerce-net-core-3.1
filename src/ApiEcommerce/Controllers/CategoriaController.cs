using ApiEcommerce.Model;
using AutoMapper;
using Core.Arquitetura;
using Microsoft.AspNetCore.Mvc;
using ModelData.Model;
using ModelData.ViewModel;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : BaseApiController<Categoria, CategoriaViewModel, ParametroDePaginacao>
    {
        public CategoriaController(IGenericRepository<Categoria> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}