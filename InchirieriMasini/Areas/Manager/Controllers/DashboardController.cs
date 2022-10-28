using InchirieriMasini.DataAccess.Data;
using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using InchirieriMasini.Models.ViewModels;
using InchirieriMasini.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InchirieriMasini.Areas.Manager.Controllers
{

    [Area("Manager")]
    [Authorize(Roles = StaticData.Role_Manager)]

    public class DashboardController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        //GET
        public IActionResult Index()
        {
            DashboardVM dateDashboard = new DashboardVM();


            var totalIncasari = _db.Comenzi.Select(u => u.TotalComanda).Sum();

            var totalTranzactii = _db.Comenzi.Select(u => u.IdComanda).Count();
            var medieZile = _db.Comenzi.Select(u => u.Durata).Average();
            var numarClienti = _db.Comenzi.Select(u => u.ClientId).Distinct().Count();
            var venitMediuClient = totalIncasari / numarClienti;
            var valoareMedieComanda = totalIncasari / totalTranzactii;

            var iduriMasini = _db.Comenzi.Select(u => u.IdMasina).Distinct().ToList();
            var max = 0;
            var idMasina = 0;
            foreach (var id in iduriMasini)
            {
                var numar = _db.Comenzi.Where(u => u.IdMasina == id).Select(u => u.IdMasina).Count();
                if (numar > max)
                {
                    max = numar;
                    idMasina = id;
                }

            }
            var ceaMaiInchiriataMasina = _db.Masini.Where(u => u.IdMasina == idMasina).Select(u => u.ModelMasina);

            dateDashboard.medieZileInchiriere = medieZile;
            dateDashboard.totalIncasari = totalIncasari;
            dateDashboard.totalTranzactii = totalTranzactii;
            dateDashboard.numarClienti = numarClienti;
            dateDashboard.venitMediuPerClient = venitMediuClient;
            dateDashboard.valoareMedieComanda = valoareMedieComanda;
            dateDashboard.ceaMaiInchiriataMasina = "Audi E-Tron";


            return View(dateDashboard);
        }
        public IActionResult GraficVanzari()
        {
            //List<GraficVanzari> graficVanzari = new List<GraficVanzari>();

            //    for (int day=1; day<=DateTime.Now.Day; day++)
            //    {
            //        var label = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);

            //    var y = _db.Comenzi.Where(u => u.DataComanda.Day == day && u.DataComanda.Month == DateTime.Now.Month && u.DataComanda.Year == DateTime.Now.Year)
            //    .Select(u => u.TotalComanda).Sum();


            //        graficVanzari.Add(new GraficVanzari(label, y));

            //    };

            
            //var data = JsonConvert.SerializeObject(graficVanzari);

            return PartialView();
        }

        public IActionResult GraphicPie()
        {
            //List<GraficPie> graficPie = new List<GraficPie>();

            //for (int day = 1; day <= DateTime.Now.Day; day++)
            //{
            //    var label = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);

            //    var y = _db.Comenzi.Where(u => u.DataComanda.Day == day && u.DataComanda.Month == DateTime.Now.Month && u.DataComanda.Year == DateTime.Now.Year)
            //    .Select(u => u.TotalComanda).Sum();


            //    graficVanzari.Add(new GraficVanzari(label, y));

            //};


            //var data = JsonConvert.SerializeObject(graficVanzari);

            return PartialView();
        }

        public IActionResult Comenzi()
        {

            return View();
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Comanda> comenzi;
            comenzi = _unitOfWork.Comanda.GetAll(includeProperties: "ApplicationUser,Client,Masina");
            return Json(new { data = comenzi });
        }
        #endregion

    }
}
