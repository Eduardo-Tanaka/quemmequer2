using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_QMQ.ViewsModel
{
    public class IndividualViewModel
    {
        public PersonViewModel Person { get; set; }
        
        [Display(Name="Nome")]
        public string Name { get; set; }

        [Display(Name="CPF")]
        public string Cpf { get; set; }

        [Display(Name="RG")]
        public string Rg { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Telefone Residencial")]
        public string Phone1 { get; set; }

        [Display(Name = "Telefone Celular")]
        public string Phone2 { get; set; }
    }
}