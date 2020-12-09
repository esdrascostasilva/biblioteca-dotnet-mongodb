using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class ManipulandoClassesExternas
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //Inicialization a variabel of type book obj
            Livro livro = new Livro();
            livro.Titulo = "Os sete hábitos das pessoas altamente eficazes";
            livro.Autor = "Stephen Covey";
            livro.Paginas = 381;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Best Seller");
            listaAssuntos.Add("Auto Ajuda");
            livro.Assunto = listaAssuntos;

            //Accessing from the connection class
            var conexaoBiblioteca = new ConectandoMongoDB();

            //Including document
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento incluso");

        }
    }
}
