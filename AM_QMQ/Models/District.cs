using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_DISTRICT")]
    public class District
    {
        [Column("COD_DISTRICT")]
        public int DistrictId { get; set; }

        [Column("NAM_DISTRICT")]
        public string Name { get; set; }

        [Column("COD_CITY")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}