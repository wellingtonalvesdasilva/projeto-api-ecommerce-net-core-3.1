using Core.Arquitetura;
using ModelData.Context;
using ModelData.Model;

namespace Repository
{
    public class CategoriaRepository : GenericRepository<EcommerceContext, Categoria>, IGenericRepository<Categoria>
    {
        public CategoriaRepository(EcommerceContext context) : base(context)
        { }
    }
}
