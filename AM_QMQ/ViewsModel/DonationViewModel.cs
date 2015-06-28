using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_QMQ.ViewsModel
{
    public class DonationViewModel
    {
        public int DonationId { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Situação")]
        public string Situation { get; set; }

        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Launch { get; set; }

    }
}