using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMarcaMasinaRepository MarcaMasina { get; }
        IMasinaRepository Masina { get; }
        ICosRepository Cos { get; }
        ILocatieRepository Locatie { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IDateConfidentialeRepository DateConfidentiale { get; }
        IClientRepository Client { get; }
        IComandaRepository Comanda { get; } 

        void Save();
    }
}
