using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kino_Bilietu_Sistema.Models;
using Kino_Bilietu_Sistema.Views.ShowTime;


namespace Kino_Bilietu_Sistema.Controllers.AdminConstrollers
{
    public class ShowTimeController : Controller
    {
        FilmoPradlaikai filmuPradLaikRepo = new FilmoPradlaikai();
        Filmas filmRepo = new Filmas();
        Sale saleRepo = new Sale();
        RodymoLaikas showTimeRepo = new RodymoLaikas();


        public ActionResult Index()
        {
            ShowTimeCreate ShowTimeCreateViewModel = new ShowTimeCreate();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(ShowTimeCreateViewModel);
            return View(ShowTimeCreateViewModel);

        }

        public ActionResult RepertoryPage()
        {
            ShowTimeCreate ShowTimeCreateViewModel = new ShowTimeCreate();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(ShowTimeCreateViewModel);
            ViewBag.MyList = ShowTimeCreateViewModel.Filmo_Prad_List;
            ModelState.Clear();
            return View(showTimeRepo.SelectRepertory());
        }

        // GET: Repertory
        public ActionResult SelectHalls()
        {
            ShowTimeCreate ShowTimeCreateViewModel = new ShowTimeCreate();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(ShowTimeCreateViewModel);
            return View(ShowTimeCreateViewModel);

        }

        public ActionResult EditShowTime()
        {
            ShowTimeCreate ShowTimeCreateViewModel = new ShowTimeCreate();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(ShowTimeCreateViewModel);
            return View(ShowTimeCreateViewModel);
        }

        [HttpPost]
        public ActionResult EditShowTime(ShowTimeCreate collection)
        {
            try
            {
                //Pridedamas naujas automobilis
                showTimeRepo.insertAndUpdate(collection);
                return RedirectToAction("SelectHalls");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }

        }

        public void PopulateSelections(ShowTimeCreate SaleCreateViewModel)
        {
            var filmuPradLaikai = filmuPradLaikRepo.getFilmoPradLaikai();
            var sales = saleRepo.getSales();
            var filmai = filmRepo.getMovie();


            List<SelectListItem> selectListFilmuPradLaik = new List<SelectListItem>();
            List<SelectListItem> selectListSales = new List<SelectListItem>();
            List<SelectListItem> selectListFilmai = new List<SelectListItem>();

            //užpildomas kebulų sąrašas iš duomenų bazės
            foreach (var item in filmuPradLaikai)
            {
                selectListFilmuPradLaik.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.name });
            }
            foreach (var item in sales)
            {
                selectListSales.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pavadinimas });
            }
            foreach (var item in filmai)
            {
                selectListFilmai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pavadinimas });
            }

            //Sarašai priskiriami vaizdo objektui
            SaleCreateViewModel.Filmo_Prad_List = selectListFilmuPradLaik;
            SaleCreateViewModel.Sale_List = selectListSales;
            SaleCreateViewModel.Filmai_List = selectListFilmai;
        }
    }
}