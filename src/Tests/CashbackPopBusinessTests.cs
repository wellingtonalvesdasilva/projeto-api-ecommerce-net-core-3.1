using Business;
using Business.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Interface;

namespace Tests
{
    [TestClass]
    public class CashbackPopBusinessTests : ICashbackBusinessTest
    {
        private ICashbackBusiness regraDeNegocio;

        [TestInitialize]
        public void Inicializar()
        {
            var factoryBusiness = new BusinessFactory<ICashbackBusiness>();
            regraDeNegocio = factoryBusiness.CriarRecurso(new ModelData.Model.Categoria { Nome = "Pop" });
        }

        [TestMethod]
        public void ValidarPercentualDomingo()
        {
            decimal percentualEsperado = 25m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Sunday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualSegundaFeira()
        {
            decimal percentualEsperado = 7m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Monday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualTercaFeira()
        {
            decimal percentualEsperado = 6m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Tuesday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualQuartaFeira()
        {
            decimal percentualEsperado = 2m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Wednesday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualQuintaFeira()
        {
            decimal percentualEsperado = 10m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Thursday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }


        [TestMethod]
        public void ValidarPercentualSextaFeira()
        {
            decimal percentualEsperado = 15m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Friday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualSabado()
        {
            decimal percentualEsperado = 20m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Saturday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }
    }
}
