using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorWeb.Controllers
{
    public class VisualizarController : Controller
    {
        public ActionResult Index(int id = -1)
        {
            if (id == -1)
                return RedirectToAction("Index", "Home");

            ViewBag.Id = id;

            return View();
        }
    }
}
