using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using InchirieriMasini.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Security.Claims;

namespace InchirieriMasini.Areas.Client.Controllers
{
    [Area("Client")]
    public class SummaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SummaryController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Summary(Cos cos)
        {
            DateComandaVM dateComanda = new()
            {
                Cos = _unitOfWork.Cos.GetFirstOrDefault(u => u.IdCos == cos.IdCos, includeProperties: "ApplicationUser,Masina,Locatie")

            };
            Masina masina = _unitOfWork.Masina.GetFirstOrDefault(u => u.IdMasina == cos.IdMasina, includeProperties: "MarcaMasina");
            dateComanda.Cos.Masina = masina;
            return View(dateComanda);
        }
        [HttpPost]
        public IActionResult Summary(DateComandaVM dateComanda)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            InchirieriMasini.Models.Client client = dateComanda.Client;
            dateComanda.Client.ApplicationUserId = claim.Value;
            InchirieriMasini.Models.Client clientFromDb = _unitOfWork.Client.GetFirstOrDefault(u => u.Nume == dateComanda.Client.Nume && u.Prenume == dateComanda.Client.Prenume && u.ApplicationUserId==claim.Value,includeProperties:"ApplicationUser");
            DateConfidentiale dateFromDb=new();
            DateConfidentiale dateConfidentiale = new();
            if (clientFromDb == null)
            {
                _unitOfWork.Client.Add(client);
                _unitOfWork.Save();
                dateConfidentiale = new()
                {
                    ClientID=client.ClientID,
                    CNP = dateComanda.DateConfidentiale.CNP,
                    SerieCI = dateComanda.DateConfidentiale.SerieCI,
                    NumarCI = dateComanda.DateConfidentiale.NumarCI
                };
            }
            else
            {
                _unitOfWork.Client.Update(client);
                _unitOfWork.Save();
                dateFromDb = _unitOfWork.DateConfidentiale.GetFirstOrDefault(u => u.ClientID == clientFromDb.ClientID, includeProperties: "Client");
                dateConfidentiale = new()
                {
                    ClientID = clientFromDb.ClientID,
                    CNP = dateComanda.DateConfidentiale.CNP,
                    SerieCI = dateComanda.DateConfidentiale.SerieCI,
                    NumarCI = dateComanda.DateConfidentiale.NumarCI
                };
            }

            
            if (dateFromDb==null)
            {
                
                _unitOfWork.DateConfidentiale.Add(dateConfidentiale);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.DateConfidentiale.Update(dateConfidentiale, dateFromDb.IdDate);
                _unitOfWork.Save();
            }
            
            Cos cosFromDb = _unitOfWork.Cos.GetFirstOrDefault(u => u.IdCos == dateComanda.Cos.IdCos, includeProperties:"Masina");
            dateComanda.Cos = cosFromDb;
            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            Comanda comanda = new()
            {
                IdComanda= str,
                IdMasina = dateComanda.Cos.IdMasina,
                DataInceput = dateComanda.Cos.DataInceput,
                DataSfarsit = dateComanda.Cos.DataSfarsit,
                Durata = dateComanda.Cos.NumarZile,
                TotalComanda = dateComanda.Cos.TarifTotal,
                TarifPeZi = dateComanda.Cos.TarifTotal / dateComanda.Cos.NumarZile,
                ClientId = clientFromDb.ClientID,
                ApplicationUserId = claim.Value,
                StatusPlata = InchirieriMasini.Utility.StaticData.StatusPlataPending,
            };
            _unitOfWork.Comanda.Add(comanda);

            _unitOfWork.Save();
            long Tarif =(long)dateComanda.Cos.TarifTotal / dateComanda.Cos.NumarZile;
            dateComanda.Cos.Masina=_unitOfWork.Masina.GetFirstOrDefault(u=>u.IdMasina==dateComanda.Cos.IdMasina,includeProperties:"MarcaMasina");
            //Stripe settings

            var domain= "https://localhost:44320/";
            var options = new SessionCreateOptions
            {
                    LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = Tarif * 100,
                      Currency = "RON",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name =  dateComanda.Cos.Masina.MarcaMasina.DenumireMarca+ " " + dateComanda.Cos.Masina.ModelMasina,
                      },
                    },
                    Quantity = dateComanda.Cos.NumarZile,
                  },
                },
                    Mode = "payment",
                    SuccessUrl = domain+$"client/summary/ConfirmareComanda?IdComanda={str}",
                    CancelUrl = domain+$"client/summary/summary",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            comanda.IdSesiune = session.Id;
            comanda.StatusPlata = session.PaymentStatus;
            _unitOfWork.Comanda.Update(comanda);
            _unitOfWork.Save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
   
        }

        public IActionResult ConfirmareComanda(string IdComanda)
        {
            Comanda comanda = _unitOfWork.Comanda.GetFirstOrDefault(u => u.IdComanda == IdComanda);
            var service = new SessionService();
            Session session = service.Get(comanda.IdSesiune);
            
            if (session.PaymentStatus.ToLower() == "paid")
            {
                comanda.StatusPlata = InchirieriMasini.Utility.StaticData.StatusPlataApproved;
                _unitOfWork.Comanda.Update(comanda);
                _unitOfWork.Save();

            }
            Cos cos =_unitOfWork.Cos.GetFirstOrDefault(u=>u.ApplicationUserId==comanda.ApplicationUserId);
            _unitOfWork.Cos.Remove(cos);
            _unitOfWork.Save();

            return View();
        }
    }
}
