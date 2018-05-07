using System;
using System.Collections.Generic;
using System.Text;

namespace PlanejamentoViagem.Classes
{
    public class Roteiro
    {
        public int IdRoteiro { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public IEnumerable<RoteiroLocalInteresse> Locais { get; set; }
        public Viajante Viajante { get; set; }
        public int IdViajante { get; set; }
    }
}