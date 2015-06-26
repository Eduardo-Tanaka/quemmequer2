using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_ADDRESS")]
    public class Address
    {
        [Column("COD_ADDRESS")]
        public int AddressId { get; set; }

        [Column("DES_PATIO")]
        public string Patio { get; set; }

        [Column("NUM_ADDRESS")]
        public int Number { get; set; }

        [Column("NUM_CEP")]
        public string Cep { get; set; }

        [Column("DES_ADDITION")]
        public string Addition { get; set; }

        [Column("COD_DISTRICT")]
        public int? DistrictId { get; set; }
        public virtual District District { get; set; }

        [Column("COD_CITY")]
        public int City { get; set; }
    }
}