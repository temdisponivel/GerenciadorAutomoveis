using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorAutomoveis.Models
{
    public class Automovel
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public Marca marca { get; set; }
        public float preco { get; set; }
        public int ano { get; set; }
        public List<Opcional> opcionais { get; set; }
    }
}