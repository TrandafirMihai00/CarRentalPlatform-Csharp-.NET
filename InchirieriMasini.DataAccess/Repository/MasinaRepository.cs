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
    public class MasinaRepository : Repository<Masina>, IMasinaRepository
    {
        private ApplicationDbContext _db;

        public MasinaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Masina obj)
        {
            var objFromDb = _db.Masini.FirstOrDefault(u => u.IdMasina == obj.IdMasina);
            if (objFromDb != null){
                objFromDb.ModelMasina = obj.ModelMasina;
                objFromDb.AnFabricatie = obj.AnFabricatie;
                objFromDb.DisponibilitateMasina = obj.DisponibilitateMasina;
                objFromDb.NumarInmatriculare = obj.NumarInmatriculare;
                objFromDb.TipCombustibil = obj.TipCombustibil;
                objFromDb.NumarUsi = obj.NumarUsi;
                objFromDb.TipCutieViteza = obj.TipCutieViteza;
                objFromDb.MasaTotala = obj.MasaTotala;
                objFromDb.TarifPeZi = obj.TarifPeZi;
                objFromDb.IdMarca = obj.IdMarca;
                if(obj.ImagineMasina1 != null)
                {
                    objFromDb.ImagineMasina1 = obj.ImagineMasina1;
                }
                if (obj.ImagineMasina2 != null)
                {
                    objFromDb.ImagineMasina2 = obj.ImagineMasina2;
                }
                if (obj.ImagineMasina3 != null)
                {
                    objFromDb.ImagineMasina3 = obj.ImagineMasina3;
                }
            }
        }
    }
}
