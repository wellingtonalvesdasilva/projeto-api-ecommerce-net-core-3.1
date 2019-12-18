using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ModelData.Model;
using ModelData.ViewModel;

namespace ApiEcommerce.Mapper
{
    public class MapeamentoViewModel
    {
        public static void RegistrarMapeamento(IServiceCollection services)
        {
            var configuracaoMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoriaViewModel, Categoria>();
                config.CreateMap<Categoria, CategoriaViewModel>();
                config.CreateMap<ClienteViewModel, Cliente>();
                config.CreateMap<Cliente, ClienteViewModel>();
                config.CreateMap<DiscoViewModel, Disco>();
                config.CreateMap<Disco, DiscoViewModel>();
                config.CreateMap<VendaViewModel, Venda>();
                config.CreateMap<Venda, VendaViewModel>();
                config.CreateMap<VendaItemViewModel, VendaItem>();
                config.CreateMap<VendaItem, VendaItemViewModel>();
            });
            IMapper mapper = configuracaoMapper.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
