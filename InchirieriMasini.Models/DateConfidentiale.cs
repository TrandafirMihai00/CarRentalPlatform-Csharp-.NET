using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InchirieriMasini.Models
{
    public class DateConfidentiale
    {
        [Key]
        public int IdDate { get; set; }
        [Required]
        [StringLength(13)]
        public string CNP { get; set; }
        public string SerieCI { get; set; }
        public int NumarCI { get; set; }  

        [Required]
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        [ValidateNever]
        public virtual Client Client { get; set; }

    }
}
