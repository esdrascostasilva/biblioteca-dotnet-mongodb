using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class ListandoDocumentos
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var conexaoBiblioteca = new ConectandoMongoDB();
            Console.WriteLine("Documento incluso");

            var listaLivros = await conexaoBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }

        }
    }
}
