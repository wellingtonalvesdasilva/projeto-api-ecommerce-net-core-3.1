namespace ApiEcommerce.Model
{
    public class ConfiguracaoSpotify
    {
        public string UrlBase { get; set; }
        public string UrlTokenDeAcesso { get; set; }
        public string UrlCategoria { get; set; }
        public string UrlAlbum { get; set; }
        public string ClienteId { get; set; }
        public string ClienteSecret { get; set; }
        public int NumeroDeTentativas { get; set; }
    }
}
