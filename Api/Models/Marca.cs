using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("nome")]
        [MaxLength(255)]
        public string nome { get; set; }
    }
}