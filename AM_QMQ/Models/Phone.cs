using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_PHONE")]
    public class Phone
    {
        [Column("COD_PHONE")]
        public int PhoneId { get; set; }

        [Column("NUM_DDD")]
        public int Ddd { get; set; }

        [Column("NUM_PHONE")]
        public int Number { get; set; }

        [Column("COD_PERSON")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}