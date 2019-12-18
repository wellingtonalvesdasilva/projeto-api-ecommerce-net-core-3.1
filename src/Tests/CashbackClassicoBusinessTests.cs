using Business;
using Business.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CashbackClassicoBusinessTests
    {
        private ICashbackBusiness regraDeNegocio;

        [TestInitialize]
        public void Inicializar()
        {
            var factoryBusiness = new BusinessFactory<ICashbackBusiness>();
            regraDeNegocio = factoryBusiness.CriarRecurso(new ModelData.Model.Categoria { Nome = "Clássico" });
        }

        [TestMethod]
        public void ValidarPercentualDomingo()
        {
            decimal percentualEsperado = 35m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Sunday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualSegundaFeira()
        {
            decimal percentualEsperado = 3m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Monday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualTercaFeira()
        {
            decimal percentualEsperado = 5m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Tuesday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualQuartaFeira()
        {
            decimal percentualEsperado = 8m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Wednesday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualQuintaFeira()
        {
            decimal percentualEsperado = 13m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Thursday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }


        [TestMethod]
        public void ValidarPercentualSextaFeira()
        {
            decimal percentualEsperado = 18m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Friday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualSabado()
        {
            decimal percentualEsperado = 25m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Saturday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }
    }
}
