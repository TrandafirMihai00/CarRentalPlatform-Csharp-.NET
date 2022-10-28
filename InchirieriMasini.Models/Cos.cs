using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InchirieriMasini.Models
{
    public class Cos
    {
        [Key]
        public int IdCos { get; set; }
        [Required]
        public DateTime DataInceput { get; set; }
        [Required]
        public DateTime DataSfarsit { get; set; }
        public int NumarZile { get; set; }
        public double TarifTotal { get; set; }
        [Required]
        public int IdMasina { get; set; }
        [ForeignKey("IdMasina")]
        [ValidateNever]
        public Masina Masina { get; set; }
        [Required]
        public int IdLocatie { get; set; }
        [ForeignKey("IdLocatie")]
        [ValidateNever]
        public Locatie Locatie { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
