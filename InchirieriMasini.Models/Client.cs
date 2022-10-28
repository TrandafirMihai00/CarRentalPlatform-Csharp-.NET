using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InchirieriMasini.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public string Prenume { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Oras { get; set; }
        [Required]
        public string Judet { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string CodPostal { get; set; }

        public virtual DateConfidentiale DateConfidentiale { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
