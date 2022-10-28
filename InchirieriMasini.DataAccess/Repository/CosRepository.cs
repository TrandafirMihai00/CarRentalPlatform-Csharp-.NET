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
    public class CosRepository : Repository<Cos>, ICosRepository
    {
        private ApplicationDbContext _db;

        public CosRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Cos obj)
        {
            var objFromDb = _db.Cos.FirstOrDefault(u => u.IdCos == obj.IdCos);
            if (objFromDb != null){
                objFromDb.DataInceput = obj.DataInceput;
                objFromDb.DataSfarsit = obj.DataSfarsit;
                objFromDb.NumarZile = obj.NumarZile;
                objFromDb.TarifTotal = obj.TarifTotal;
                objFromDb.IdMasina = obj.IdMasina;
            }
        }
    }
}
