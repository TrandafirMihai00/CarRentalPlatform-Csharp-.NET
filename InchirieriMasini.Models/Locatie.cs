using System.ComponentModel.DataAnnotations;


namespace InchirieriMasini.Models
{
    public class Locatie
    {
        [Key]
        public int IdLocatie { get; set; }
        [Required]
        public string DenumireLocatie { get; set; }
    }
}
