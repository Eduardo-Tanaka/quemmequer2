using AM_QMQ.Models;
using AM_QMQ.UnitsOfWork;
using AM_QMQ.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AM_QMQ.Controllers
{
    public class PessoaController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(PersonViewModel model)
        {
            if (model.Password != model.Password2)
            {
                ModelState.AddModelError("Password", "Senhas Não Conferem");
                return View();
            }
            if (_unit.PersonRepository.SearchFor(p => p.UserName == model.UserName).Count != 0)
            {
                ModelState.AddModelError("UserName", "Nome de Usuário já Cadastrado");
                return View();
            }
            if (_unit.PersonRepository.SearchFor(p => p.Email == model.Email).Count != 0)
            {
                ModelState.AddModelError("Email", "Email já Cadastrado");
                return View();
            }
            if (ModelState.IsValid)
            {
                if (model.Type == "I")
                {
                    List<Phone> list = new List<Phone>();
                    list.Add(new Phone());
                    list.Add(new Phone());
                    var individual = new PersonIndividual
                    {
                        PersonId = model.PersonId,
                        Status = "A",
                        FiledDate = DateTime.Today,
                        Email = model.Email,
                        Password = model.Password,
                        Type = "I",
                        UserName = model.UserName,
                        BirthDate = DateTime.Parse("11/11/1800"),
                        Phones = list,
                        Address = new Address()
                    };
                    _unit.PersonRepository .Add(individual);
                    _unit.Save();
                }

                if (model.Type == "L")
                {
                    List<Phone> list = new List<Phone>();
                    list.Add(new Phone());
                    var legal = new PersonLegal
                    {
                        PersonId = model.PersonId,
                        Status = "A",
                        FiledDate = DateTime.Today,
                        Email = model.Email,
                        Password = model.Password,
                        Type = "L",
                        UserName = model.UserName,
                        Phones = list,
                        Address = new Address()
                    };
                    _unit.PersonRepository.Add(legal);
                    _unit.Save();
                }

                TempData["msg"] = "Usuário Cadastrado!";
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Editar()
        {
            List<Person> person = (List<Person>)_unit.PersonRepository.SearchFor(p => p.UserName == User.Identity.Name);
            if (person[0].Type == "I")
            {
                return RedirectToAction("EditarFisica");
            }
            else
            {
                return RedirectToAction("EditarJuridica");
            }
        }

        [HttpGet]
        public ActionResult EditarFisica()
        {
            // Recupera a pessoa através do nome de usuário do Cookie
            List<Person> person = (List<Person>)_unit.PersonRepository.SearchFor(m => m.UserName == User.Identity.Name);
            
            // Recupera a pessoa física
            PersonIndividual individual = _unit.IndividualRepository.SearchById(person[0].PersonId);
            
            // Telefones 
            List<Phone> list = individual.Phones.ToList();           
            string p1 = list[0].Ddd + "" + list[0].Number;
            string p2 = list[1].Ddd + "" + list[1].Number;

            // Dados da Pessoa
            PersonViewModel p = new PersonViewModel();
            p.PersonId = individual.PersonId;
            p.Email = individual.Email;
            p.FiledDate = individual.FiledDate;
            p.UserName = individual.UserName;
            p.Password = individual.Password;
            p.Type = individual.Type;
            p.Status = individual.Status;
            p.Ranking = individual.Ranking;
            
            // Dados do Endereço
            p.Address = new AddressViewModel();
            p.Address.Addition = individual.Address.Addition;
            p.Address.AddressId = individual.Address.AddressId;
            p.Address.Cep = individual.Address.Cep;
            p.Address.Number = individual.Address.Number;
            p.Address.Patio = individual.Address.Patio;
            // Verifica se já houve alteração, para não buscar valor nulo
            if (individual.Address.City != 0)
            {
                p.Address.District = individual.Address.District.Name;
                p.Address.City = individual.Address.District.City.Name;
                p.Address.State = individual.Address.District.City.State.Abb;
            }
            else
            {
                p.Address.City = "";
                p.Address.District = "";
                p.Address.State = "";
            }
          
            // Dados pessoa física
            IndividualViewModel model = new IndividualViewModel
            {
                Person = p,
                Name = individual.Name,
                Cpf = individual.Cpf,
                Rg = individual.Rg,
                BirthDate = individual.BirthDate,
                Phone1 = p1,
                Phone2 = p2
            };
            return View(model);
             
        }

        [HttpPost]
        public ActionResult EditarFisica(IndividualViewModel model)
        {
           // if (ModelState.IsValid)
          //  {
                // Recupera a pessoa através do nome de usuário do Cookie
                List<PersonIndividual> individual = (List<PersonIndividual>)_unit.IndividualRepository.SearchFor(p => p.UserName == User.Identity.Name);
                
                // Telefone
                List<Phone> list = individual[0].Phones.ToList();
                list[0].Ddd = Convert.ToInt32(model.Phone1.Substring(1, 2));
                list[0].Number = Convert.ToInt32(model.Phone1.Substring(4).Replace("-", ""));
                list[1].Ddd = Convert.ToInt32(model.Phone2.Substring(1, 2));
                list[1].Number = Convert.ToInt32(model.Phone2.Substring(4).Replace("-",""));

                // Endereço
                individual[0].Address.Patio = model.Person.Address.Patio;
                individual[0].Address.Number = model.Person.Address.Number;
                individual[0].Address.Cep = model.Person.Address.Cep;
                individual[0].Address.Addition = model.Person.Address.Addition;

                // Código da cidade caso ela não possua bairro para poder recuperar o endereço
                List<City> cities = (List<City>)_unit.CityRepository.SearchFor(c => c.Name == model.Person.Address.City && c.State.Abb == model.Person.Address.State);
                int cityId = cities[0].CityId;
                individual[0].Address.City = cityId;

                // Bairro do endereço
                List<District> districts = (List<District>)_unit.DistrictRepository.SearchFor(d => d.Name == model.Person.Address.District && d.City.Name == model.Person.Address.City);
                int districtId = districts[0].DistrictId;
                individual[0].Address.District = districts[0];

                // Dados pessoa fisica
                individual[0].BirthDate = model.BirthDate;
                individual[0].Cpf = model.Cpf;
                individual[0].Name = model.Name;
                individual[0].Rg = model.Rg;
                individual[0].Phones = list;

                // Faz e comita as alterações
                _unit.IndividualRepository.Update(individual[0]);
                _unit.AddressRepository.Update(individual[0].Address);
                _unit.Save();
                TempData["msg"] = "Usuário Alterado!";
                return View();            
            //}
          /*  else
            {
                TempData["msg"] = ModelState.;
                return View();
            }*/
        }

        public ActionResult EditarJuridica()
        {
            return View();
        }

        public ActionResult Listar()
        {
            return View(_unit.PersonRepository.List());
        }

        [HttpGet]
        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(LogarViewModel usuario, string returnUrl)
        {
            var p = _unit.PersonRepository.Logar(usuario.Email, usuario.Password);
            if (p != null)
            {
                FormsAuthentication.SetAuthCookie(p.UserName, false);
                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                TempData["msg"] = "Usuário ou senha Inválidos";
                return View();
            }
        }

        public ActionResult Deslogar()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logar", "Pessoa");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}