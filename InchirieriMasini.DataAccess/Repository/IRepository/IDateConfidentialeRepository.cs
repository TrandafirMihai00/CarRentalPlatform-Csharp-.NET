using InchirieriMasini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.DataAccess.Repository.IRepository
{
    public interface IDateConfidentialeRepository : IRepository<DateConfidentiale>
    {
        void Update(DateConfidentiale obj, int id);
    }
}
