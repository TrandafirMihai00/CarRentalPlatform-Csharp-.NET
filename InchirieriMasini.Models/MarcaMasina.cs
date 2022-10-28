using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InchirieriMasini.Models
{
    public class MarcaMasina
    {
        [Key]
        public int IdMarca { get; set; }
        [Required]
        [DisplayName("Denumire marca")]
        public string DenumireMarca { get; set; }
        [Required]
        [DisplayName("URL logo")]
        [FileExtensions(Extensions =".png", ErrorMessage ="Fisierul trebuie sa fie de tipul PNG.")]
        public string LogoURL { get; set; }

        [DisplayName("Data crearii")]
        public DateTime DataCrearii { get; set; } = DateTime.Now;

    }
}
