using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kino_Bilietu_Sistema.Views.ShowTime
{
    public class ShowTimeCreate
    {
        [DisplayName("id_Rodymo_laikas")]
        [Required]
        public int id_Rodymo_laikas { get; set; }
        [DisplayName("Laikas")]
        [Required]
        public string[] laikas { get; set; }
        [DisplayName("filmas")]
        [Required]
        public int[] fk_Filmasid_Filmas { get; set; }
        [DisplayName("Kino Salė")]
        [Required]
        public int[] fk_Kino_saleid_Kino_sale { get; set; }
        [DisplayName("Prad. laikas")]
        [Required]
        public int[] filmo_prad_laik { get; set; }

        [Required]
        public bool confirmation { get; set; }

        public IList<SelectListItem> Filmai_List { get; set; }
        public IList<SelectListItem> Sale_List { get; set; }
        public IList<SelectListItem> Filmo_Prad_List { get; set; }
    }
}