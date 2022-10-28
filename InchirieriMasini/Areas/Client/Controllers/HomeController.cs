using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using InchirieriMasini.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Security.Claims;

namespace InchirieriMasini.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CatalogMasini()
        {
            IEnumerable<Masina> listaMasini = _unitOfWork.Masina.GetAll(includeProperties: "MarcaMasina");
            return View(listaMasini);
        }
        public IActionResult Masina(int? IdMasina)
        {
            CosVM masinaCos = new()
            {
                ListaLocatii = _unitOfWork.Locatie.GetAll().Select(i => new SelectListItem
                {
                    Text = i.DenumireLocatie,
                    Value = i.IdLocatie.ToString()
                }),
                Cos = new()
                {
                    Masina = _unitOfWork.Masina.GetFirstOrDefault(u => u.IdMasina == IdMasina, includeProperties: "MarcaMasina"),
                    DataInceput = DateTime.Now.AddDays(1),
                    DataSfarsit = DateTime.Now.AddDays(2),
                    IdMasina = (int)IdMasina
                }
            };
            return View(masinaCos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Masina(Cos? cos)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            cos.ApplicationUserId = claim.Value;
            cos.NumarZile = (int)(cos.DataSfarsit - cos.DataInceput).TotalDays;
            Masina masina = _unitOfWork.Masina.GetFirstOrDefault(u => u.IdMasina == cos.IdMasina, includeProperties: "MarcaMasina");
            if (cos.NumarZile < 0)
            {
                throw new Exception("Intervalul ales este invalid");
            }
            if (cos.NumarZile < 7)
            {
                cos.TarifTotal = cos.NumarZile * masina.TarifPeZi;
            }
            else if(cos.NumarZile>7 && cos.NumarZile < 30)
            {
                cos.TarifTotal = (cos.NumarZile * masina.TarifPeZi)*0.9;
            }
            else
            {
                cos.TarifTotal = (cos.NumarZile * masina.TarifPeZi) * 0.85;
            }
            
            

            _unitOfWork.Cos.Add(cos);
            _unitOfWork.Save();

            return RedirectToAction("Summary","Summary",cos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public IActionResult IstoricComenzi()
        {
            return View();
        }
        #region API CALLS
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            IEnumerable<Comanda> comenzi;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            comenzi = _unitOfWork.Comanda.GetAll(includeProperties: "ApplicationUser,Client,Masina").Where(u=>u.ApplicationUserId==claim.Value);
            return Json(new { data = comenzi });
        }
        #endregion
    }
}