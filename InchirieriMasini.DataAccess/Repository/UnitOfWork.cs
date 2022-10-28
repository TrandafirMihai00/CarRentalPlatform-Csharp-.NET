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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            MarcaMasina = new MarcaMasinaRepository(_db);
            Masina = new MasinaRepository(_db);
            Cos = new CosRepository(_db);
            Locatie = new LocatieRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            DateConfidentiale = new DateConfidentialeRepository(_db);
            Client = new ClientRepository(_db);
            Comanda = new ComandaRepository(_db);
        }

        public IMarcaMasinaRepository MarcaMasina { get; private set; }
        public IMasinaRepository Masina { get; private set; }
        public ICosRepository Cos { get; private set; }
        public ILocatieRepository Locatie { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IDateConfidentialeRepository DateConfidentiale { get; private set; }
        public IClientRepository Client { get; private set; }
        public IComandaRepository Comanda { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
