using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Kino_Bilietu_Sistema.Models;
using Kino_Bilietu_Sistema.Views.Filmas;
using Kino_Bilietu_Sistema.Views.ShowTime;

namespace Kino_Bilietu_Sistema.Controllers.AdminConstrollers
{
    public class FilmasController : Controller
    {
        Filmas filmaiRepo = new Filmas();
        Zanras zanraiRepo = new Zanras();
        // GET: Filmas
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(filmaiRepo.getMovie());
        }

        public ActionResult Create()
        {
            FilmasCreate filmasCreateViewModel = new FilmasCreate();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(filmasCreateViewModel);
            return View(filmasCreateViewModel);
        }

        [HttpPost]
        public ActionResult Create(FilmasCreate collection)
        {
            try
            {
                //Pridedamas naujas automobilis
                filmaiRepo.addMovie(collection);

                //Nukreipia i sąrašą
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public void PopulateSelections(FilmasCreate filmasCreateViewModel)
        {
            var zanrai = zanraiRepo.getZanras();

            List<SelectListItem> selectListZanrai = new List<SelectListItem>();
            //užpildomas kebulų sąrašas iš duomenų bazės
            foreach (var item in zanrai)
            {
                selectListZanrai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pav });
            }

            //Sarašai priskiriami vaizdo objektui
            filmasCreateViewModel.ZanraiList = selectListZanrai;
        }

    }
}