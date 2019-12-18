using Core.Arquitetura;
using ModelData.Context;
using ModelData.Model;

namespace Repository
{
    public class VendaRepository : GenericRepository<EcommerceContext, Venda>, IGenericRepository<Venda>
    {
        public VendaRepository(EcommerceContext context) : base(context)
        { }
    }
}
