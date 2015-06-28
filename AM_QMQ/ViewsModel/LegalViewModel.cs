using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_QMQ.ViewsModel
{
    public class LegalViewModel
    {
        public PersonViewModel Person { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string TradingName { get; set; }

        [Display(Name = "Razão Social")]
        public string CompanyName { get; set; }

        [Display(Name = "Cnpj")]
        public string Cnpj { get; set; }

        [Display(Name = "Telefone")]
        public string Phone1 { get; set; }

    }
}