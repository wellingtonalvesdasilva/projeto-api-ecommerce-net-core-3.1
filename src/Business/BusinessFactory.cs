using Business.Interface;
using ModelData.Model;
using System;
using Util;

namespace Business
{
    public interface IBusinessFactory<TBusiness> where TBusiness : ICashbackBusiness
    {
        TBusiness CriarRecurso(Categoria categoria);
    }

    public class BusinessFactory<TBusiness> : IBusinessFactory<TBusiness> where TBusiness : ICashbackBusiness
    {
        public TBusiness CriarRecurso(Categoria categoria)
        {
            return (TBusiness)Activator.CreateInstance(Type.GetType("Business.Cashback" + categoria.Nome.RemoveAcentos().RemoveCaracterEspeciais() + "Business"));
        }
    }
}
