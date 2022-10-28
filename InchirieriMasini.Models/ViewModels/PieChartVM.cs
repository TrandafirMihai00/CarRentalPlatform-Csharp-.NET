using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.Models.ViewModels
{
    public class PieChartVM
    {
        public string label { get; set; }
        public int y { get; set; }

        public PieChartVM (string label,int y){
            this.label = label;
            this.y = y;
        }
    }
}
