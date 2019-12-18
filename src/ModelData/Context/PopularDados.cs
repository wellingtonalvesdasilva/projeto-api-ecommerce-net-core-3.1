using ModelData.Model;
using System.Collections.Generic;
using System.Linq;
using static Util.Enumeracao;

namespace ModelData.Context
{
    public class PopularDados
    {
        public void DadosIniciais(EcommerceContext context)
        {
            if (!context.Cliente.Any())
            {
                var clientes = new List<Cliente>();

                //insere 20 clientes na base inicial para teste
                for (int i = 1; i <= 20; i++)
                    clientes.Add(new Cliente
                    {
                        Nome = "Cliente " + i,
                        Status = (int)ESituacao.Ativo
                    });

                context.AddRange(clientes);
                context.SaveChanges();
            }
        }
    }
}
