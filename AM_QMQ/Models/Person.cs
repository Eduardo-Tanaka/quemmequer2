using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_PERSON")]
    public class Person
    {
        [Column("COD_PERSON")]
        public int PersonId { get; set; }

        [Column("DES_EMAIL")]
        public string Email { get; set; }

        [Column("DES_PASSWORD")]
        public string Password { get; set; }

        [Column("DES_STATUS")]
        public string Status { get; set; }

        [Column("DES_TYPE")]
        public string Type { get; set; }

        [Column("NAM_USER")]
        public string UserName { get; set; }

        [Column("DAT_FILED")]
        public DateTime FiledDate { get; set; }
    }
}