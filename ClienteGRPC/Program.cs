using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using ServicoMisto;

namespace ClienteGRPC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch(
            "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            /*
             * Ignora o certificado do servidor
             * https://docs.microsoft.com/pt-br/aspnet/core/grpc/troubleshoot?view=aspnetcore-3.1
             * var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;*/

            var channel = GrpcChannel.ForAddress("http://servico-misto:5010");
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(
                new HelloRequest { Name = "World" });

            Console.WriteLine(response.Message);


            /*var client = new Catalogo.CatalogoClient(channel);

            var lista = client.ProdutosListar(new EmpresaIdRequest { Id = Guid.NewGuid().ToString() });

            foreach (var item in lista.Data)
            {
                Console.WriteLine($"{item.Id} -> {item.CodigoProtheus}: {item.Descricao}");
            }*/

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
