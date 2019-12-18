namespace ModelData.ViewModel
{
    public class VendaItemViewModel
    {
        public long Id { get; set; }

        public DiscoViewModel Disco { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int Quantidade { get; set; }
    }
}
