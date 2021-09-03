using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace ServicoGRPC
{
    public class CatalogoService : Catalogo.CatalogoBase
    {
        private readonly ILogger<CatalogoService> _logger;

        public CatalogoService(ILogger<CatalogoService> logger)
        {
            _logger = logger;
        }

        public override async Task<ProdutosResponse> ProdutosListar(EmpresaIdRequest request, ServerCallContext context)
        {
            var result = new ProdutosResponse();
            var lista = Listar();

            foreach (var item in lista)
            {
                result.Data.Add(new ProdutoResponse
                {
                    Id = item.Id.ToString(),
                    Descricao = item.Descricao,
                    CodigoProtheus = item.CodigoProtheus
                });
            }
            return result;
        }

        private IEnumerable<Produto> Listar()
        {
            var lista = new List<Produto>();

            lista.Add(new Produto(Guid.NewGuid(), "PRODUTO TESTE I", "00001"));
            lista.Add(new Produto(Guid.NewGuid(), "PRODUTO TESTE II", "00002"));
            lista.Add(new Produto(Guid.NewGuid(), "PRODUTO TESTE III", "00003"));
            lista.Add(new Produto(Guid.NewGuid(), "PRODUTO TESTE IV", "00004"));
            lista.Add(new Produto(Guid.NewGuid(), "PRODUTO TESTE V", "00005"));
            lista.Add(new Produto(Guid.NewGuid(), "PRODUTO TESTE VI", "00006"));

            return lista;
        }

    }

    public class Produto
    {
        public Produto(Guid id, string descricao, string codigoProtheus)
        {
            Id = id;
            Descricao = descricao;
            CodigoProtheus = codigoProtheus;
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string CodigoProtheus { get; set; }
    }
}
