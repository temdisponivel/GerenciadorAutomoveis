using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Models
{
    [Table("Opcionais")]
    public class Opcional
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        
        [Column("descricao")]
        [MaxLength(255)]
        public string descricao { get; set; }
    }
}