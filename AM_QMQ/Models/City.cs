using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_CITY")]
    public class City
    {
        [Column("COD_CITY")]
        public int CityId { get; set; }

        [Column("NAM_CITY")]
        public string Name { get; set; }

        [Column("COD_STATE")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}