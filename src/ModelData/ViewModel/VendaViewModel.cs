using System.Collections.Generic;

namespace ModelData.ViewModel
{
    public class VendaViewModel
    {
        public long Id { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public decimal CashBackTotal { get; set; }

        public virtual List<VendaItemViewModel> Itens { get; set; }
    }
}
