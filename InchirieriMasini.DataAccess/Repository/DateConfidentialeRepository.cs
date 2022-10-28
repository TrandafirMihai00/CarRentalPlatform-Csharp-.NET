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
    public class DateConfidentialeRepository : Repository<DateConfidentiale>, IDateConfidentialeRepository
    {
        private ApplicationDbContext _db;

        public DateConfidentialeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DateConfidentiale obj, int id)
        {
            var objFromDb = _db.DateConfidentiale.FirstOrDefault(u => u.IdDate == id);
            if (objFromDb != null)
            {
                objFromDb.CNP = obj.CNP;
                objFromDb.SerieCI = obj.SerieCI;
                objFromDb.NumarCI = obj.NumarCI;
            }
        }
    }
}
