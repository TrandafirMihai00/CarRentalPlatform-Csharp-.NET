using InchirieriMasini.DataAccess.Data;
using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.DataAccess.Repository
{
    public class ComandaRepository : Repository<Comanda>, IComandaRepository
    {
        private ApplicationDbContext _db;

        public ComandaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Comanda obj)
        {
            var objFromDb = _db.Comenzi.FirstOrDefault(u => u.IdComanda == obj.IdComanda);
            if (objFromDb != null)
            {
                objFromDb.IdMasina = obj.IdMasina;
                objFromDb.DataInceput = obj.DataInceput;
                objFromDb.DataSfarsit = obj.DataSfarsit;
                objFromDb.Durata = obj.Durata;
                objFromDb.TotalComanda = obj.TotalComanda;
                objFromDb.TarifPeZi = obj.TarifPeZi;
                objFromDb.ClientId = obj.ClientId;
                objFromDb.ApplicationUserId = obj.ApplicationUserId;
                objFromDb.StatusPlata = obj.StatusPlata;
                objFromDb.IdSesiune = obj.IdSesiune;
                objFromDb.IdIntentiePlata = obj.IdIntentiePlata;
            }
        }
    }
}
