using Business;
using Business.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CashbackMPBBusinessTests
    {
        private ICashbackBusiness regraDeNegocio;

        [TestInitialize]
        public void Inicializar()
        {
            var factoryBusiness = new BusinessFactory<ICashbackBusiness>();
            regraDeNegocio = factoryBusiness.CriarRecurso(new ModelData.Model.Categoria { Nome = "MPB" });
        }

        [TestMethod]
        public void ValidarPercentualDomingo()
        {
            decimal percentualEsperado = 30m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Sunday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualSegundaFeira()
        {
            decimal percentualEsperado = 5m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Monday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualTercaFeira()
        {
            decimal percentualEsperado = 10m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Tuesday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualQuartaFeira()
        {
            decimal percentualEsperado = 15m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Wednesday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualQuintaFeira()
        {
            decimal percentualEsperado = 20m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Thursday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }


        [TestMethod]
        public void ValidarPercentualSextaFeira()
        {
            decimal percentualEsperado = 25m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Friday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }

        [TestMethod]
        public void ValidarPercentualSabado()
        {
            decimal percentualEsperado = 30m;
            decimal percentualCalculado = regraDeNegocio.ObterPercentualCashback(System.DayOfWeek.Saturday);

            Assert.AreEqual(percentualEsperado, percentualCalculado);
        }
    }
}
