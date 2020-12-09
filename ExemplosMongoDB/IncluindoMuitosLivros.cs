using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDB
{
    class IncluindoMuitosLivros
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

            //Creating a List of books for pass as parameter
            List<Livro> livros = new List<Livro>();
            livros.Add(ValoresLivro.IncluiValoresLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"));
            livros.Add(ValoresLivro.IncluiValoresLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"));
            livros.Add(ValoresLivro.IncluiValoresLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação"));

            //Including document
            await conexaoBiblioteca.Livros.InsertManyAsync(livros);

            Console.WriteLine("Documento incluso");

        }
    }
}
