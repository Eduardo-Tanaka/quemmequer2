using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_PHONE_TYPE")]
    public class PhoneType
    {
        [Column("COD_PHONE_TYPE")]
        public int PhoneTypeId { get; set; }

        [Column("DES_PHONE_TYPE")]
        public string Type { get; set; }

    }
}