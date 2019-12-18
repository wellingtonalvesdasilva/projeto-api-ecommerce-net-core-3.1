using ApiEcommerce.Interface;
using ApiEcommerce.Model;
using Core.Arquitetura;
using ModelData.Model;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Util;

namespace ApiEcommerce.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly ConfiguracaoSpotify _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGenericRepository<Categoria> _categoriaRepository;
        private readonly IGenericRepository<Disco> _discoRepository;
        private RetryPolicy<HttpResponseMessage> _clientPolicySpotify;

        public string TokenDeAcesso { get; set; }

        public SpotifyService(
            ConfiguracaoSpotify config,
            IHttpClientFactory httpClientFactory,
            IGenericRepository<Categoria> categoriaRepository,
            IGenericRepository<Disco> discoRepository)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
            _categoriaRepository = categoriaRepository;
            _discoRepository = discoRepository;
            _clientPolicySpotify = CriarPoliticaDeTentativa();
        }

        public string AtualizarTokenDeAcesso()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("spotifyCliente");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","client_credentials")
            });

            var base64Cliente = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_config.ClienteId}:{_config.ClienteSecret}"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Cliente);

            var result = httpClient.PostAsync(_config.UrlTokenDeAcesso, content).Result;
            var json = JsonConvert.DeserializeAnonymousType(result.Content.ReadAsStringAsync().Result, new
            {
                access_token = string.Empty,
                token_type = string.Empty,
                scope = string.Empty,
                expires_in = 0,
                refresh_token = string.Empty
            });

            return json.access_token;
        }

        public void RealizarCargaInicial()
        {
            //se por ventura já foi realizado a carga, não realiza mais :)
            if (_categoriaRepository.ObterTodos().Count() > 0)
                return;

            HttpClient httpClient = _httpClientFactory.CreateClient("spotifyCliente");

            var categoriasBase = new List<string>
            {
                "pop",
                "mpb",
                "classical",
                "rock"
            };

            foreach (var categoria in categoriasBase)
            {
                var categoriaNova = ObterCategoriaResult(httpClient, categoria);
                _categoriaRepository.Criar(categoriaNova);

                var discosNovos = ObterAlbumDaCategoriaResult(httpClient, categoriaNova);
                discosNovos.ForEach(p => _discoRepository.Criar(p));
            }
        }

        private Categoria ObterCategoriaResult(HttpClient httpClient, string categoria)
        {
            var response = _clientPolicySpotify.Execute(() =>
            {
                var urlCategoria = string.Format(_config.UrlCategoria, categoria);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenDeAcesso);
                return httpClient.GetAsync(urlCategoria).Result;
            });
           
            var retornoCategoria = JsonConvert.DeserializeAnonymousType(
                response.Content.ReadAsStringAsync().Result,
                new
                {
                    icons = new[]
                    {
                        new
                        {
                            url = string.Empty
                        }
                    },
                    name = string.Empty
                }
            );

            return new Categoria
            {
                DataDeCriacao = DateTime.Now,
                ImagemURL = retornoCategoria.icons.First().url,
                Nome = retornoCategoria.name,
                Status = (int)Enumeracao.ESituacao.Ativo
            };
        }

        private List<Disco> ObterAlbumDaCategoriaResult(HttpClient httpClient, Categoria categoria)
        {
            var response = _clientPolicySpotify.Execute(() =>
            {
                var urlAlbum = string.Format(_config.UrlAlbum, categoria.Nome);
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", TokenDeAcesso);
                return httpClient.GetAsync(urlAlbum).Result;
            });

            var retornoAlbum = JsonConvert.DeserializeAnonymousType(
                response.Content.ReadAsStringAsync().Result,
                new
                {
                    albums = new
                    {
                        href = string.Empty,
                        items = new[]
                        {
                            new {
                                id = string.Empty,
                                name = string.Empty
                            }
                        }
                    }
                }
            );

            var discos = new List<Disco>();
            Random randNum = new Random();

            foreach (var album in retornoAlbum.albums.items)
            {
                discos.Add(new Disco
                {
                    Categoria_Id = categoria.Id,
                    DataDeCriacao = DateTime.Now,
                    Nome = album.name,
                    Preco = randNum.Next(100), //numero aleatório até 100
                    Status = (int)Enumeracao.ESituacao.Ativo
                });
            }

            return discos;
        }

        private RetryPolicy<HttpResponseMessage> CriarPoliticaDeTentativa()
        {
            return Policy
                .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.Unauthorized || r.StatusCode == HttpStatusCode.BadRequest)
                .Retry(_config.NumeroDeTentativas, (exception, retryCount) =>
                {
                    var token = AtualizarTokenDeAcesso();
                    if (!string.IsNullOrEmpty(token))
                        TokenDeAcesso = token;
                });
        }
    }
}
