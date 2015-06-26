using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_QMQ.ViewsModel
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }

        [Display(Name = "Endereço")]
        public string Patio { get; set; }

        [Display(Name = "Número")]
        public int Number { get; set; }

        public string Cep { get; set; }

        [Display(Name = "Complemento")]
        public string Addition { get; set; }

        [Display(Name = "Cidade")]
        public string City { get; set; }
        
        [Display(Name = "Bairro")]
        public string District { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }
    }
}