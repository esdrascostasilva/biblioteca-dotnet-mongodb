using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    public class ManipulandoClasses
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //var doc = new BsonDocument
            //{
            //    { "Titulo", "Guerra dos Tronos" }
            //};
            //doc.Add("Autor", "George R. R. Martin");
            //doc.Add("Ano", 1999);
            //doc.Add("Paginas", 856);

            //var assuntoArray = new BsonArray();
            //assuntoArray.Add("Fantasia");
            //assuntoArray.Add("Ação");
            //doc.Add("Assunto", assuntoArray);

            //Console.WriteLine(doc);

            //Inicialization a variabel of type book obj
            Livro livro = new Livro();
            livro.Titulo = "Código Limpo 2";
            livro.Autor = "Robert C. Martin";
            livro.Paginas = 456;

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Programação");
            listaAssuntos.Add("Clean Code");
            listaAssuntos.Add("Design Patterns");
            livro.Assunto = listaAssuntos;

            //Doing the connection with server

            //access the MongoDB server
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //access the database
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //access the collection
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            //Including document
            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento incluso");

        }
    }
}
