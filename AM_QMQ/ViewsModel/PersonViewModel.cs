using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_QMQ.ViewsModel
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage="Email Inválido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha Obrigatória")]
        public string Password { get; set; }

        [Display(Name = "Confirmação de Senha")]
        [Required(ErrorMessage = "Confirmação de Senha Obrigatória")]
        public string Password2 { get; set; }

        public int Ranking { get; set; }

        public string Status { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Escolha um Tipo de Usuário")]
        public string Type { get; set; }

        [Display(Name = "Nome de Usuário")]
        [Required(ErrorMessage = "Nome de Usuário Obrigatório")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateTime FiledDate { get; set; }

        public int PhoneId1 { get; set; }

        public int PhoneId2 { get; set; }

        public AddressViewModel Address { get; set; }

    }
}