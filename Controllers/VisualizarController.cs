using GerenciadorAutomoveis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorAutomoveis.Controllers
{
    public class VisualizarController : Controller
    {
        readonly IAutomoveisRepositorio repositorio = new AutomoveisRepositorio();

        public ActionResult Index(int id = -1)
        {
            ViewBag.Automovel = repositorio.GetId(id);
            ViewBag.Marcas = repositorio.GetMarcas();
            ViewBag.Opcionais = repositorio.GetOpcionais();

            if (ViewBag.Automovel == null)
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
