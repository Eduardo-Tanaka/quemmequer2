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
    public class PessoaWSController : ApiController
    {
        private UnitOfWork _unit = new UnitOfWork();

        public IEnumerable<Person> Get()
        {
            return _unit.PessoaRepository.List();
        }

    }
}
