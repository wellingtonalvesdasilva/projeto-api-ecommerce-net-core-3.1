# projeto-api-ecommerce-net-core-3.1
Projeto de uma API de um ecommerce que vende discos de vinil na qual foram aplicados designer patterns, testes unitários, documentação da API, automapper e muito mais, visando as melhores práticas

## Orientação

Para rodar utilizando Migrations e o banco SQL Server abrir o VS2019, marcar "ApiEcommerce" como "Set as StartUp Project" e dois ir até Tools -> Nugget Package Manage -> Package Manager Console -> Selectionar como Default project: ModelData, e aplicar o comando abaixo:

``` csharp
Update-Database
```

Com esse comando a aplicação irá criar as estruturas do banco de dados.

Em sequência apertar F5 o projeto será compilado e executado, e apresentará a tela do Swagger, caso não apareça digite: https://localhost:44357/swagger

Se por ventura optar por querer rodar em memória, segue as orientações:

Ir até o projeto ApiEcommerce -> Startup.cs e descomentar o código da linha 39 do arquivo ficando assim:

``` csharp
services.AddDbContext<EcommerceContext>(options => options.UseInMemoryDatabase(databaseName: "VendasDatabase"));
```
Em seguida comentar o código da linha 41, ficando assim:
``` csharp
//services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```

Basicamente é isso, e para demonstração de uso da API, utilizar o Swagger, pois esse projeto contempla apenas o back-end.

Vale ressaltar que ao rodar a aplicação não terá dados, logo utilizando o Swagger executar o método POST /api/Spotify/RealizarCargaInicial essa operação fará a carga inicial dos dados utilizando a API do Spotify
