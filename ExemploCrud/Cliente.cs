using System;

namespace ExemploCrud {
    public class Cliente {
        public int IDCliente { get; set; }
        public string nomeCliente { get; set; }
        public string emailCliente { get; set; }
        public string cpf { get; set; }
        public DateTime dataCadastro { get; set; }
    }
}