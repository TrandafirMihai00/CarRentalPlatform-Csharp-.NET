using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.Models.ViewModels
{
    public class DashboardVM
    {
        public string ceaMaiInchiriataMasina { get; set; }
        public double medieZileInchiriere { get; set; }
        public double totalIncasari { get; set; }
        public int totalTranzactii { get; set; }
        public int numarClienti { get; set; }
        public double venitMediuPerClient { get; set; }
        public double valoareMedieComanda { get; set; }


    }
}
