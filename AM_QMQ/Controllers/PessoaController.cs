﻿using AM_QMQ.Models;
using AM_QMQ.UnitsOfWork;
using AM_QMQ.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Cadastrar(PersonViewModel model, string password2)
        {
            if (model.Password != password2)
            {
                ModelState.AddModelError("Password", "Senhas Não Conferem");
                return View();
            }
            if (_unit.PessoaRepository.SearchFor(p => p.Email == model.Email).Count != 0)
            {
                ModelState.AddModelError("Email", "Email já Cadastrado");
                return View();
            }
            if (_unit.PessoaRepository.SearchFor(p => p.UserName == model.UserName).Count != 0)
            {
                ModelState.AddModelError("UserName", "Nome de Usuário já Cadastrado");
                return View();
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
                        BirthDayDate = DateTime.Today
                    };
                    _unit.PessoaRepository.Add(individual);
                    _unit.Save();
                }

                if (model.Type == "L")
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
                    _unit.PessoaRepository.Add(legal);
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

        public ActionResult Listar()
        {
            return View(_unit.PessoaRepository.List());
        }

        [HttpGet]
        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(LogarViewModel usuario, string returnUrl)
        {
            var user = _unit.PessoaRepository.Logar(usuario.Email, usuario.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
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

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}