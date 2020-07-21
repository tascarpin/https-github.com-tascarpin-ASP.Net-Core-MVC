﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes =
            new List<Instituicao>()
                {
                    new Instituicao() {
                        InstituicaoID = 1,
                        Nome = "UniParaná",
                        Endereco = "Paraná"
                    },
                    new Instituicao() {
                        InstituicaoID = 2,
                        Nome = "UniSanta",
                        Endereco = "Santa Catarina"
                    },
                    new Instituicao() {
                        InstituicaoID = 3,
                        Nome = "UniSãoPaulo",
                        Endereco = "São Paulo"
                    },
                    new Instituicao() {
                        InstituicaoID = 4,
                        Nome = "UniSulgrandense",
                        Endereco = "Rio Grande do Sul"
                    },
                    new Instituicao() {
                        InstituicaoID = 5,
                        Nome = "UniCarioca",
                        Endereco = "Rio de Janeiro"
                    }
            };

        public IActionResult Index()
        {
            //return View(instituicoes);
            return View(instituicoes.OrderBy(i => i.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            var teste = new List<Instituicao>();
            var testeId = teste.Select(i => i.InstituicaoID).DefaultIfEmpty(0).Max() + 1;
            instituicoes.Add(instituicao);
            instituicao.InstituicaoID =
                instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }
    }
}