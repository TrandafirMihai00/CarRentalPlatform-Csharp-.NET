using InchirieriMasini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.DataAccess.Repository.IRepository
{
    public interface IMarcaMasinaRepository : IRepository<MarcaMasina>
    {
        void Update(MarcaMasina obj);
    }
}
