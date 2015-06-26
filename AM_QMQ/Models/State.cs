using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_STATE")]
    public class State
    {
        [Column("COD_STATE")]
        public int StateId { get; set; }

        [Column("NAM_STATE")]
        public string Name { get; set; }

        [Column("ABB_STATE")]
        public string Abb { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}