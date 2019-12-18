using AutoMapper;
using Business.Interface;
using Core.Arquitetura;
using ModelData.Model;
using ModelData.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Business
{
    public interface IVendaBusiness
    {
        Venda RegistrarVenda(CadastroVendaViewModel vendaViewModel);
        decimal CalculoTotalDoCashback(List<VendaItem> itens);
    }

    public class VendaBusiness : IVendaBusiness
    {
        private readonly IGenericRepository<Venda> _vendaRepository;
        private readonly IGenericRepository<Disco> _discoRepository;

        private readonly IMapper _mapper;
        private readonly IBusinessFactory<ICashbackBusiness> _businessFactory;

        public VendaBusiness(
            IGenericRepository<Venda> vendaRepository,
            IGenericRepository<Disco> discoRepository,
            IMapper mapper, 
            IBusinessFactory<ICashbackBusiness> businessFactory)
        {
            _vendaRepository = vendaRepository;
            _discoRepository = discoRepository;
            _mapper = mapper;
            _businessFactory = businessFactory;
        }

        public Venda RegistrarVenda(CadastroVendaViewModel vendaViewModel)
        {
            var dataAtutal = DateTime.Now;

            var venda = new Venda
            {
                Cliente_Id = vendaViewModel.ClienteId,
                DataDeCriacao = dataAtutal,
                Status = (int)Enumeracao.ESituacao.Ativo,
                Itens = new List<VendaItem>()
            };

            vendaViewModel.Itens.ForEach(item =>
            {
                var disco = _discoRepository.ObterPorID(item.DiscoId);
                var regraDeCalculo = _businessFactory.CriarRecurso(disco.Categoria);

                venda.Itens.Add(new VendaItem
                {
                    DataDeCriacao = dataAtutal,
                    Quantidade = item.Quantidade,
                    CashBackUnitario = regraDeCalculo.ObterPercentualCashback(dataAtutal.DayOfWeek),
                    Disco_Id = disco.Id,
                    PrecoUnitario = disco.Preco,
                    Status = (int)Enumeracao.ESituacao.Ativo
                });
                
            });

            venda.CashBackTotal = CalculoTotalDoCashback(venda.Itens);
            _vendaRepository.Criar(venda);

            return venda;
        }

        public decimal CalculoTotalDoCashback(List<VendaItem> itens)
        {
            return itens.Sum(c => (c.CashBackUnitario/100) * c.PrecoUnitario * c.Quantidade);
        }
    }
}
