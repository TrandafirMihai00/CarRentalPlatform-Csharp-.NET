using InchirieriMasini.DataAccess.Data;
using InchirieriMasini.DataAccess.Repository.IRepository;
using InchirieriMasini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.DataAccess.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private ApplicationDbContext _db;

        public ClientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Client obj)
        {
            var objFromDb = _db.Clienti.FirstOrDefault(u => u.ClientID == obj.ClientID);
            if (objFromDb != null)
            {
                objFromDb.Adresa = obj.Adresa;
                objFromDb.Telefon = obj.Telefon;
                objFromDb.Oras = obj.Oras;
                objFromDb.Judet = obj.Judet;
                objFromDb.CodPostal = obj.CodPostal;
            }
        }

    }
}
