using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_LEGAL")]
    public class PersonLegal : Person
    {
        [Column("NAM_Trading")]
        [Display(Name="Nome Fantasia")]
        public string TradingName { get; set; }

        [Column("NAM_COMPANY")]
        [Display(Name="Razao Social")]
        public string CompanyName { get; set; }

        [Column("NUM_CNPJ")]
        public long Cnpj { get; set; }
    }
}