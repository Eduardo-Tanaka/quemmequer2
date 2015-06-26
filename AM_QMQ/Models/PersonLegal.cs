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
        [Column("NAM_TRADING")]
        [MaxLength(128)]
        public string TradingName { get; set; }

        [Column("NAM_COMPANY")]
        public string CompanyName { get; set; }

        [Column("NUM_CNPJ")]
        public string Cnpj { get; set; }
    }
}