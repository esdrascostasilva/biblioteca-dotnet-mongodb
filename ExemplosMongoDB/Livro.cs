using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExemplosMongoDB
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }

        
    }

    public class ValoresLivro
    {
        public static Livro IncluiValoresLivro(string titulo, String autor, int ano, int paginas, string assuntos)
        {
            Livro livro = new Livro();
            livro.Titulo = titulo;
            livro.Autor = autor;
            livro.Ano = ano;
            livro.Paginas = paginas;
            
            string[] vetAssunto = assuntos.Split(',');
            List<string> vetAssunto2 = new List<string>();
            for (int i = 0; i < vetAssunto.Length; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }
            livro.Assunto = vetAssunto2;

            return livro;
        }
    }
}
