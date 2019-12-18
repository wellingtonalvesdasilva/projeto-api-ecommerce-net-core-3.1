using Core.Arquitetura;
using ModelData.Context;
using ModelData.Model;

namespace Repository
{
    public class VendaItemRepository : GenericRepository<EcommerceContext, VendaItem>, IGenericRepository<VendaItem>
    {
        public VendaItemRepository(EcommerceContext context) : base(context)
        { }
    }
}
