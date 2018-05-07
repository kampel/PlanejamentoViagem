using System;
using System.Collections.Generic;
using System.Text;

namespace PlanejamentoViagem.Classes
{
    public class RoteiroLocalInteresse
    {
        public int IdRoteiro { get; set; }
        public Roteiro Roteiro { get; set; }
        public int IdLocalInteresse { get; set; }
        public LocalInteresse LocalInteresse { get; set; }
    }
}
