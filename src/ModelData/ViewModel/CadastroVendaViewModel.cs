using System.Collections.Generic;

namespace ModelData.ViewModel
{
    public class CadastroVendaViewModel
    {
        public long ClienteId { get; set; }
        public virtual List<CadastroVendaItemViewModel> Itens { get; set; }
    }

    public class CadastroVendaItemViewModel
    {
        public long DiscoId { get; set; }

        public int Quantidade { get; set; }
    }
}
