using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AM_QMQ.ViewsModel
{
    public class LogarViewModel
    {
        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha Obrigatória")]
        public string Password { get; set; }
    }
}