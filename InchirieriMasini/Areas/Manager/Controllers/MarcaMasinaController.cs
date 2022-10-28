using InchirieriMasini.DataAccess.Data;
using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using InchirieriMasini.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InchirieriMasini.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = StaticData.Role_Manager)]

    public class MarcaMasinaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarcaMasinaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<MarcaMasina> objListaMarci = _unitOfWork.MarcaMasina.GetAll();
            return View(objListaMarci);
        }
        //GET
        public IActionResult Creare()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creare(MarcaMasina obj)
        {
            if (obj.DenumireMarca == obj.LogoURL)
            {
                ModelState.AddModelError("logourl", "Ai uitat sa precizezi tipul fisierului!");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.MarcaMasina.Add(obj);
                _unitOfWork.Save();
                TempData["succes"] = "Marca creata!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Editare(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var marcaDb = _unitOfWork.MarcaMasina.GetFirstOrDefault(u => u.IdMarca == id);
            if (marcaDb == null)
            {
                return NotFound();
            }
            return View(marcaDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editare(MarcaMasina obj)
        {
            if (obj.DenumireMarca == obj.LogoURL)
            {
                ModelState.AddModelError("logourl", "Ai uitat sa precizezi tipul fisierului!");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.MarcaMasina.Update(obj);
                _unitOfWork.Save();
                TempData["succes"] = "Marca modificata!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Stergere(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var marcaDb = _unitOfWork.MarcaMasina.GetFirstOrDefault(u => u.IdMarca == id);
            if (marcaDb == null)
            {
                return NotFound();
            }
            return View(marcaDb);
        }

        //POST
        [HttpPost, ActionName("Stergere")]
        [ValidateAntiForgeryToken]
        public IActionResult StergerePost(int? id)
        {
            var obj = _unitOfWork.MarcaMasina.GetFirstOrDefault(u => u.IdMarca == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.MarcaMasina.Remove(obj);
            _unitOfWork.Save();
            TempData["succes"] = "Marca strearsa!";
            return RedirectToAction("Index");
        }
    }
}
