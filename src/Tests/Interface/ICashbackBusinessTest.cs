using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Interface
{
    public interface ICashbackBusinessTest
    {
        [TestMethod]
        void ValidarPercentualDomingo();

        [TestMethod]
        void ValidarPercentualSegundaFeira();

        [TestMethod]
        void ValidarPercentualTercaFeira();

        [TestMethod]
        void ValidarPercentualQuartaFeira();

        [TestMethod]
        void ValidarPercentualQuintaFeira();

        [TestMethod]
        void ValidarPercentualSextaFeira();

        [TestMethod]
        void ValidarPercentualSabado();
    }
}
