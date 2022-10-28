using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InchirieriMasini.Models
{
    public class Comanda
    {
        [Key]
        public string IdComanda { get; set; }
        [Required]
        public int IdMasina { get; set; }
        [ForeignKey("IdMasina")]
        [ValidateNever]
        public Masina Masina { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public int Durata { get; set; }
        public double TarifPeZi { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        [ValidateNever]
        public Client Client { get; set; }
        [Required]
        public DateTime DataComanda { get; set; }= DateTime.Now;
        public double TotalComanda { get; set; }
        public string? StatusPlata { get; set; }

        public string? IdSesiune { get; set; }
        public string? IdIntentiePlata { get; set; }
    }
}
