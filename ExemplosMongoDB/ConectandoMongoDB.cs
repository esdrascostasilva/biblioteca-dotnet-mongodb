using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ExemplosMongoDB
{
    class ConectandoMongoDB
    {
        // Class for connection on Database
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "Biblioteca";
        public const string NOME_DA_COLECAO = "Livros";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _BaseDeDados;

        static ConectandoMongoDB()
        {
            _cliente = new MongoClient(STRING_DE_CONEXAO);
            _BaseDeDados = _cliente.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente { get { return _cliente; } }
       
        public IMongoCollection<Livro> Livros { get { return _BaseDeDados.GetCollection<Livro>(NOME_DA_COLECAO); } }


    }
}
