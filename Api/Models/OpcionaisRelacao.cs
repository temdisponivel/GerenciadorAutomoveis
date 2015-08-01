using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Models
{
    [Table("OpcionaisRelacao")]
    public class OpcionaisRelacao
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [ForeignKey("automovel")]
        [Column("automovel_id")]
        public int AutomovelId { get; set; }

        [ForeignKey("opcional")]
        [Column("opcional_id")]
        public int OpcionalId { get; set; }

        virtual public Automovel automovel { get; set; }
        virtual public Opcional opcional { get; set; }
    }
}