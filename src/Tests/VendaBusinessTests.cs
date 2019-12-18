using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class VendaBusinessTests
    {
        [TestMethod]
        public void ValidarPercentualDomingo()
        {
            var percentualAcumuladoEsperado = Convert.ToDecimal((80 * 0.25 * 1) + (40 * 0.20 * 2) + (100 * 0.30 * 3));

            var itens = new List<ModelData.Model.VendaItem>
            {
                new ModelData.Model.VendaItem{ PrecoUnitario = 80m, CashBackUnitario = 25, Quantidade = 1 },
                new ModelData.Model.VendaItem{ PrecoUnitario = 40m, CashBackUnitario = 20, Quantidade = 2 },
                new ModelData.Model.VendaItem{ PrecoUnitario = 100m, CashBackUnitario = 30, Quantidade = 3 }
            };

            //como é um teste unitário não vou mocar os parametros da classe
            decimal percentualAcumuladoCalculado = new VendaBusiness(null, null, null, null).CalculoTotalDoCashback(itens);

            Assert.AreEqual(percentualAcumuladoEsperado, percentualAcumuladoCalculado);
        }
    }
}
