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
    public class MarcaMasinaRepository : Repository<MarcaMasina>, IMarcaMasinaRepository
    {
        private ApplicationDbContext _db;

        public MarcaMasinaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(MarcaMasina obj)
        {
            _db.MarciMasini.Update(obj);
        }
    }
}
