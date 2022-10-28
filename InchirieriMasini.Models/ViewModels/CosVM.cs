using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.Models.ViewModels
{
    public class CosVM
    {
        public Cos Cos { get; set; }
        public IEnumerable<SelectListItem> ListaLocatii { get; set; }
    }
}
