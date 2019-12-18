using ApiEcommerce.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        /// <summary>
        /// Retorna o token de acesso
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RefreshToken")]
        public string RefreshToken()
        {
            return _spotifyService.AtualizarTokenDeAcesso();
        }

        /// <summary>
        /// Realizar uma carga inicial de dados
        /// </summary>
        [HttpPost]
        [Route("RealizarCargaInicial")]
        public void RealizarCargaInicial()
        {
            _spotifyService.RealizarCargaInicial();
        }
    }
}