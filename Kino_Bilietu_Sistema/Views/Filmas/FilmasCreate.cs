using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Kino_Bilietu_Sistema.Views.Filmas
{
    public class FilmasCreate
    {
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }
        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }
        [DisplayName("Trukmė")]
        [Required]
        public int trukme { get; set; }
        [DisplayName("Aktoriai")]
        [Required]
        public string aktoriai { get; set; }
        [DisplayName("Režisierius")]
        [Required]
        public string rezisierius { get; set; }
        [DisplayName("Žanras")]
        [Required]
        public int zanras { get; set; }
        [DisplayName("Aprašymas")]
        [Required]
        public string aprasymas { get; set; }
        [DisplayName("Anonsas")]
        [Required]
        public string anonsas { get; set; }

        public IList<SelectListItem> ZanraiList { get; set; }

    }
}