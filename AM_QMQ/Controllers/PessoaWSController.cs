using AM_QMQ.Models;
using AM_QMQ.UnitsOfWork;
using AM_QMQ.ViewsModel;
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

        public IHttpActionResult Get()
        {
            return BadRequest("Email já cadastrado");
           // return _unit.PessoaRepository.List();
        }

        public IEnumerable<Person> GetPersonByEmail(string email)
        {
            return _unit.PersonRepository.SearchFor(p => p.Email == email);
        }

        public IHttpActionResult Post(PersonViewModel model)
        {
            if (_unit.PersonRepository.SearchFor(p => p.UserName == model.UserName).Count != 0)
            {
                ModelState.AddModelError("UserName", "Nome de Usuário já Cadastrado");
                return BadRequest(ModelState);
            }
            if (_unit.PersonRepository.SearchFor(p => p.Email == model.Email).Count != 0)
            {
                return BadRequest("Email já cadastrado");
            }
            if (ModelState.IsValid)
            {
                if (model.Type == "I")
                {
                    var individual = new PersonIndividual
                    {
                        PersonId = model.PersonId,
                        Status = "0",
                        FiledDate = DateTime.Today,
                        Email = model.Email,
                        Password = model.Password,
                        Type = "I",
                        UserName = model.UserName,
                        //BirthDate = DateTime.Today
                    };
                    _unit.PersonRepository.Add(individual);
                    _unit.Save();
                    var uri = Url.Link("DefaultApi", new { id = model.PersonId });
                    return Created<PersonIndividual>(new Uri(uri), individual);
                }
                else if (model.Type == "L")
                {
                    var legal = new PersonLegal
                    {
                        PersonId = model.PersonId,
                        Status = "0",
                        FiledDate = DateTime.Today,
                        Email = model.Email,
                        Password = model.Password,
                        Type = "L",
                        UserName = model.UserName
                    };
                    _unit.PersonRepository.Add(legal);
                    _unit.Save();
                    var uri = Url.Link("DefaultApi", new { id = model.PersonId });
                    return Created<PersonLegal>(new Uri(uri), legal);
                }
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
