﻿using InchirieriMasini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.DataAccess.Repository.IRepository
{
    public interface ILocatieRepository : IRepository<Locatie>
    {
        void Update(Locatie obj);
    }
}
