namespace ModelData.ViewModel
{
    public class DiscoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public CategoriaViewModel Categoria { get; set; }
    }
}
