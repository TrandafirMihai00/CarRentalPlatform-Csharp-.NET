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
    public class LocatieRepository : Repository<Locatie>, ILocatieRepository
    {
        private ApplicationDbContext _db;

        public LocatieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Locatie obj)
        {
            var objFromDb = _db.Locatii.FirstOrDefault(u => u.IdLocatie == obj.IdLocatie);
            if (objFromDb != null){
                objFromDb.IdLocatie = obj.IdLocatie;
                objFromDb.DenumireLocatie = obj.DenumireLocatie; 
            }
        }
    }
}
