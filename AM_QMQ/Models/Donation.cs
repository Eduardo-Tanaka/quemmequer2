using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_DONATION")]
    public class Donation
    {
        [Column("COD_DONATION")]
        public int DonationId { get; set; }

        [Column("DES_TITLE")]
        public string Title { get; set; }

        [Column("DES_DONATION")]
        public string Description { get; set; }

        [Column("DES_SITUATION")]
        public string Situation { get; set; }

        [Column("STA_DONATION")]
        public string Status { get; set; }

        [Column("DAT_LAUNCH")]
        [DataType(DataType.Date)]
        public DateTime Launch { get; set; }

        [Column("COD_PERSON")]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}