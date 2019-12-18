using System;

namespace ApiEcommerce.Model
{
    public class FiltroVenda: ParametroDePaginacao
    {
        public DateTime? DataInicial { get; set; }

        public DateTime? DataFinal { get; set; }
    }
}
