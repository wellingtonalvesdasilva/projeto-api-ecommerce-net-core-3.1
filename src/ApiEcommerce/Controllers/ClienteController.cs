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
    public class ClienteController : BaseApiController<Cliente, ClienteViewModel, ParametroDePaginacao>
    {
        public ClienteController(IGenericRepository<Cliente> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}