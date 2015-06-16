using AM_QMQ.Models;
using AM_QMQ.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AM_QMQ.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LogarWSController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public Person Post(Person person)
        {
            var user = _unit.PessoaRepository.Logar(person.Email, person.Password);
            if (user == null)
            {
                Person p = new Person();
                p.Email = "Invalido";
                return p;
            }
            else
            {
                return user;
            }
        }
        
    }
}
