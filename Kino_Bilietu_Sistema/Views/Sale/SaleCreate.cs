using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Kino_Bilietu_Sistema.Views.Sale
{
    public class SaleCreate
    {
        [DisplayName("id_Kino_sale")]
        [Required]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Eil. Nr")]
        [Required]
        public int[] eiles_nr { get; set; }
        [DisplayName("Viet. Nr")]
        [Required]
        public int[] vietos_nr { get; set; }
        [DisplayName("Viet tipas")]
        [Required]
        public int[] vietos_tipas { get; set; }
        [DisplayName("id_Vieta")]
        [Required]
        public int id_Vieta { get; set; }
        [DisplayName("fk_Kino_saleid_Kino_sale")]
        [Required]
        public int fk_Kino_saleid_Kino_sale { get; set; }

        public IList<SelectListItem> vietos_tipasList{ get; set; }
    
    }
}