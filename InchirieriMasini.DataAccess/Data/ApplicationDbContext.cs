using InchirieriMasini.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InchirieriMasini.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<MarcaMasina> MarciMasini { get; set; }
        public DbSet<Masina> Masini { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Cos> Cos { get; set; }
        public DbSet<Locatie> Locatii { get; set; }
        public DbSet<DateConfidentiale> DateConfidentiale { get; set; }
        public DbSet<Client> Clienti { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }

    }
}
