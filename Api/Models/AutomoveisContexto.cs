using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class AutomoveisContext : DbContext
    {
        public DbSet<Automovel> Automoveis { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Opcional> Opcionais { get; set; }
        public DbSet<OpcionaisRelacao> OpcionaisRelacao { get; set; }

        public AutomoveisContext() : base("GerenciadorAutomoveis") { }

        public void GetOpcionais(ref Automovel aut)
        {
            int id = aut.id;
            var opcionais = from opc in this.OpcionaisRelacao.Where(opcrelac => opcrelac.AutomovelId == id) select opc.opcional;

            aut.opcionais = opcionais.ToList<Opcional>();
        }
    }
}