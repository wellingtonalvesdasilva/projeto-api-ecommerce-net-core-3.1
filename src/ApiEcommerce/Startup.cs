using ApiEcommerce.Interface;
using ApiEcommerce.Mapper;
using ApiEcommerce.Model;
using ApiEcommerce.Services;
using Business;
using Business.Interface;
using Core.Arquitetura;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ModelData.Context;
using ModelData.Model;
using Repository;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Net.Http;

namespace ApiEcommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Banco em Memória para poder publicar no Azure
            //services.AddDbContext<EcommerceContext>(options => options.UseInMemoryDatabase(databaseName: "VendasDatabase"));

            services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Cria um única instancia das configurações do spotify
            var config = new ConfiguracaoSpotify();
            Configuration.Bind("ConfiguracaoSpotify", config);
            services.AddSingleton(config);

            //Criando a injeção de dependência do service
            services.AddScoped<ISpotifyService, SpotifyService>();

            //Configura o http cliente do spotify
            services.AddHttpClient("spotifyCliente", cfg =>
            {
                cfg.BaseAddress = new Uri(config.UrlBase);
                cfg.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            })
            .ConfigurePrimaryHttpMessageHandler(h => new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip,
            });

            services.AddScoped<ISpotifyService, SpotifyService>();

            services.AddScoped<IGenericRepository<Categoria>, CategoriaRepository>();
            services.AddScoped<IGenericRepository<Cliente>, ClienteRepository>();
            services.AddScoped<IGenericRepository<Disco>, DiscoRepository>();
            services.AddScoped<IGenericRepository<Venda>, VendaRepository>();
            services.AddScoped<IGenericRepository<VendaItem>, VendaItemRepository>();

            services.AddScoped<IBusinessFactory<ICashbackBusiness>, BusinessFactory<ICashbackBusiness>>();
            
            services.AddScoped<IVendaBusiness, VendaBusiness>();

            //Registra o mapeamento da view model
            MapeamentoViewModel.RegistrarMapeamento(services);

            //Preparando o Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "API - Ecommerce de disco de vinil com cashback",
                    Description = "API em Asp .Net Core 3.1 para ecommerce de disco de vinil com cashback",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Alves da Silva",
                        Email = "wellington.alvesdasilva@hotmail.com",
                        Url = new Uri("https://github.com/wellingtonalvesdasilva")
                    }
                });

                //Obtendo o diretório e depois o nome do arquivo .xml de comentários
                //var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var applicationName = PlatformServices.Default.Application.ApplicationName;
                //var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");
                //c.IncludeXmlComments(xmlDocumentPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Preparando o Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "API v1 - Ecommerce de disco de vinil com cashback");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
