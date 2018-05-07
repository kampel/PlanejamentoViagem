using System.Collections.Generic;

namespace PlanejamentoViagem.Classes
{
    public class Viajante
    {
        public int IdViajante { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int IdEndereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Documento (CPF, Passaporte, ...)
        public IEnumerable<Roteiro> Roteiros { get; set; }
    }
}
