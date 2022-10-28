using InchirieriMasini.DataAccess.Data;
using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using InchirieriMasini.Models.ViewModels;
using InchirieriMasini.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace InchirieriMasini.Areas.Manager.Controllers;

[Area("Manager")]
[Authorize(Roles = StaticData.Role_Manager )]
public class MasinaController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public MasinaController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }
    public IActionResult Index()
    {

        return View();
    }

    //GET
    public IActionResult Upsert(int? IdMasina)
    {
        MasinaVM masinaVM = new MasinaVM()
        {
            Masina = new(),
            ListaMarci = _unitOfWork.MarcaMasina.GetAll().Select(i => new SelectListItem
            {
                Text = i.DenumireMarca,
                Value = i.IdMarca.ToString()
            })
        };
        if (IdMasina == null || IdMasina == 0)
        {
            return View(masinaVM);
        }
        else
        {
            masinaVM.Masina = _unitOfWork.Masina.GetFirstOrDefault(u => u.IdMasina == IdMasina);
            return View(masinaVM);
        }
    }
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(MasinaVM obj, IFormFile? file1, IFormFile? file2, IFormFile? file3)
    {
        if (ModelState.IsValid)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file1 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Imagini/Masini/");
                var extension = Path.GetExtension(file1.FileName);

                if (obj.Masina.ImagineMasina1 != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Masina.ImagineMasina1.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }


                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file1.CopyTo(fileStream);
                }
                obj.Masina.ImagineMasina1 = @"/Imagini/Masini/" + fileName + extension;
            }

            if (file2 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Imagini/Masini/");
                var extension = Path.GetExtension(file2.FileName);
                if (obj.Masina.ImagineMasina2 != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Masina.ImagineMasina2.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file2.CopyTo(fileStream);
                }
                obj.Masina.ImagineMasina2 = @"/Imagini/Masini/" + fileName + extension;
            }

            if (file3 != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Imagini/Masini/");
                var extension = Path.GetExtension(file3.FileName);
                if (obj.Masina.ImagineMasina3 != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Masina.ImagineMasina3.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file3.CopyTo(fileStream);
                }
                obj.Masina.ImagineMasina3 = @"/Imagini/Masini/" + fileName + extension;
            }

            obj.Masina.TarifPeSaptamana = ((obj.Masina.TarifPeZi * 7) - (10 / (float)100 * obj.Masina.TarifPeZi * 7));
            obj.Masina.TarifPeLuna = (obj.Masina.TarifPeZi * 30) - (15 / (float)100 * obj.Masina.TarifPeZi * 30);

            if (obj.Masina.IdMasina == 0)
            {
                _unitOfWork.Masina.Add(obj.Masina);
                TempData["succes"] = "Masina adaugata cu succes!";
            }
            else
            {
                _unitOfWork.Masina.Update(obj.Masina);
                TempData["succes"] = "Masina modificata cu succes!";
            }
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var listaMasini = _unitOfWork.Masina.GetAll(includeProperties: "MarcaMasina");
        return Json(new { data = listaMasini });
    }

    //POST
    [HttpDelete]
    public IActionResult Stergere(int? id)
    {
        var obj = _unitOfWork.Masina.GetFirstOrDefault(u => u.IdMasina == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Nu s-a putut efectua stergerea!" });
        }

        var oldImagePath1 = Path.Combine(_hostEnvironment.WebRootPath, obj.ImagineMasina1.TrimStart('/'));
        if (System.IO.File.Exists(oldImagePath1))
        {
            System.IO.File.Delete(oldImagePath1);
        }
        var oldImagePath2 = Path.Combine(_hostEnvironment.WebRootPath, obj.ImagineMasina2.TrimStart('/'));
        if (System.IO.File.Exists(oldImagePath2))
        {
            System.IO.File.Delete(oldImagePath2);
        }
        var oldImagePath3 = Path.Combine(_hostEnvironment.WebRootPath, obj.ImagineMasina3.TrimStart('/'));
        if (System.IO.File.Exists(oldImagePath3))
        {
            System.IO.File.Delete(oldImagePath3);
        }

        _unitOfWork.Masina.Remove(obj);
        _unitOfWork.Save();
        TempData["succes"] = "Masina eliminata!";
        return Json(new { success = true, message = "Stergerea s-a efectuat cu succes!" });
    }
    #endregion
}
