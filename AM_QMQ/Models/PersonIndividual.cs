using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AM_QMQ.Models
{
    [Table("T_JAV_INDIVIDUAL")]
    public class PersonIndividual : Person
    {
        [Column("NAM_INDIVIDUAL")]
        public string Name { get; set; }

        [Column("NUM_CPF")]
        public long Cpf { get; set; }

        [Column("DES_RG")]
        public string Rg { get; set; }
        
        [Column("DAT_BIRTH")]
        [Display(Name="Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDayDate { get; set; }
    }
}