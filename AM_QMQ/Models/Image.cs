using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_IMAGE")]
    public class Image
    {
        [Column("COD_IMAGE")]
        public int ImageId { get; set; }

        [Column("NAM_IMAGE")]
        public string Name { get; set; }

        [Column("COD_DONATION")]
        public int DonationId { get; set; }
        public virtual Donation Donation { get; set; }
    }
}