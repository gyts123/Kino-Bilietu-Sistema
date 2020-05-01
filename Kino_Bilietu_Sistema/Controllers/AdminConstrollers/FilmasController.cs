using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kino_Bilietu_Sistema.Models;

namespace Kino_Bilietu_Sistema.Controllers.AdminConstrollers
{
    public class FilmasController : Controller
    {
        Filmas filmaiRepo = new Filmas();
        // GET: Filmas
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(filmaiRepo.getMovie());
        }
    }
}