using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class AcessandoMongoDB
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");

            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //{
            //    Titulo: "Guerra dos tronos",
            //    Autor: "George R. R. Martin",
            //    Ano: 1999,
            //    Paginas: 856,
            //    Assunto: [
            //        "Fantasia, Ação"]
            //}

            var doc = new BsonDocument
            {
                { "Titulo", "Guerra dos Tronos" }
            };
            doc.Add("Autor", "George R. R. Martin");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);

            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);

            Console.WriteLine(doc);

            //Doing the connection with server

            //access the MongoDB server
            string stringConexao = "mongodb://localhost:27017";
            IMongoClient cliente = new MongoClient(stringConexao);

            //access the database
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //access the collection
            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("Livros");

            //Including document
            await colecao.InsertOneAsync(doc);

            Console.WriteLine("Documento incluso");

        }
    }
}
