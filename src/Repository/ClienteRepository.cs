using Core.Arquitetura;
using ModelData.Context;
using ModelData.Model;

namespace Repository
{
    public class ClienteRepository : GenericRepository<EcommerceContext, Cliente>, IGenericRepository<Cliente>
    {
        public ClienteRepository(EcommerceContext context) : base(context)
        { }
    }
}
