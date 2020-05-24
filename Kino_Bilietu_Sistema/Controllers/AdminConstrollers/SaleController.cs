using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kino_Bilietu_Sistema.Models;
using Kino_Bilietu_Sistema.Views.Sale;

namespace Kino_Bilietu_Sistema.Controllers.AdminConstrollers
{
    public class SaleController : Controller
    {
        Sale saleRepo = new Sale();
        VietuTipai vietuTipai = new VietuTipai();
        Vieta vietuRepo = new Vieta();
        // GET: Sale
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(saleRepo.getSales());
        }
        public ActionResult SubCreate()
        {
            return View();
        }
        public ActionResult Create()
        {
            SaleCreate SaleCreateViewModel = new SaleCreate();
            //Užpildomi pasirinkimų sąrašai duomenimis iš duomenų saugyklų
            PopulateSelections(SaleCreateViewModel);
            return View(SaleCreateViewModel);
        }

        [HttpPost]
        public ActionResult Create(SaleCreate collection)
        {
            try
            {
                //Pridedamas naujas automobilis
                saleRepo.addSale(collection);
                int a=saleRepo.getSaleId();
                vietuRepo.addVietos(collection, saleRepo.getSaleId());
                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public void PopulateSelections(SaleCreate SaleCreateViewModel)
        {
            var vt = vietuTipai.getVietuTipas();

            List<SelectListItem> selectListVietuTipai = new List<SelectListItem>();

            //užpildomas kebulų sąrašas iš duomenų bazės
            foreach (var item in vt)
            {
                selectListVietuTipai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pav });
            }

            //Sarašai priskiriami vaizdo objektui
            SaleCreateViewModel.vietos_tipasList = selectListVietuTipai;
        }
    }
}