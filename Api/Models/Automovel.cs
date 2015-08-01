using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Models
{
    [Table("Automoveis")]
    public class Automovel
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("modelo")]
        public string modelo { get; set; }

        [ForeignKey("marca")]
        [Column("marca")]
        public int marcaId { get; set; }

        [Column("preco")]
        public double preco { get; set; }

        [Column("ano")]
        public int ano { get; set; }

        virtual public Marca marca { get; set; }

        [NotMapped]
        public List<Opcional> opcionais { get; set; }
    }
}