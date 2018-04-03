using PlanejamentoViagem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanejamentoViagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco { Pais = "Brasil", Estado = "RJ", Cidade = "Rio de Janeiro" };
            Endereco endereco2 = new Endereco { Pais = "Brasil", Estado = "RJ", Cidade = "Niteroi" };
            Endereco endereco3 = new Endereco { Pais = "Brasil", Estado = "RJ", Cidade = "Teresopolis" };

            LocalInteresse local = new LocalInteresse { Endereco = endereco, Nome = "Cristo Redentor" };
            LocalInteresse local2 = new LocalInteresse { Endereco = endereco2, Nome = "MAC" };
            LocalInteresse local3 = new LocalInteresse { Endereco = endereco3, Nome = "Dedo de Deus" };

            var listaLocais = new List<LocalInteresse> { local, local2, local3 };

            var listaResultado = pesquisa(listaLocais, "Rio");
            foreach (var item in listaResultado)
            {
                Console.WriteLine(item.Nome);
            }
        }

        static List<LocalInteresse> pesquisa(List<LocalInteresse> listaLocais, string termoBuscado)
        {
            return listaLocais.Where(L => L.Endereco.Pais.Contains(termoBuscado) || L.Endereco.Cidade.Contains(termoBuscado)).ToList();
        }
    }
}
