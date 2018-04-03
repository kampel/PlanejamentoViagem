using System;
using System.Collections.Generic;
using System.Text;

namespace PlanejamentoViagem.Classes
{
    class Viajante
    {
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Documento (CPF, Passaporte, ...)
    }
}
