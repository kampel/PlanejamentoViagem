﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlanejamentoViagem.Classes
{
    public enum TipoLocalInteresse
    {
        Hospedagem,
        Atracao
    }

    public class LocalInteresse
    {
        public int IdLocalInteresse { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoLocalInteresse TipoLocalInteresse { get; set; }
        public Endereco Endereco { get; set; }
        public int IdEndereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RoteiroLocalInteresse> Roteiros { get; set; }
    }
}
