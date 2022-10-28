using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InchirieriMasini.Models
{
    public class Masina
    {
        [Key]
        public int IdMasina { get; set; }
        [Required]
        [Display(Name ="Model masina")]
        public string ModelMasina { get; set; }
        
        
        [Display(Name="Prima imagine")]
        [FileExtensions(Extensions = ".png", ErrorMessage = "Fisierul trebuie sa fie de tipul PNG.")]
        [ValidateNever]
        public string? ImagineMasina1 { get; set; }
        
        [Display(Name = "A doua imagine")]
        [FileExtensions(Extensions = ".png", ErrorMessage = "Fisierul trebuie sa fie de tipul PNG.")]
        [ValidateNever]
        public string? ImagineMasina2 { get; set; }
        
        [Display(Name = "A treia imagine")]
        [FileExtensions(Extensions = ".png", ErrorMessage = "Fisierul trebuie sa fie de tipul PNG.")]
        [ValidateNever]
        public string? ImagineMasina3 { get; set; }

        [Required]
        [Range(1990,2022)]
        [Display(Name = "An fabricatie")]
        public int AnFabricatie { get; set; }
        [Required]
        [Display(Name = "Disponibilitate")]
        public bool DisponibilitateMasina { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(7)]
        [Display(Name = "Numar inmatriculare")]
        public string NumarInmatriculare { get; set; }
        [Required]
        [Display(Name = "Tip combustibil")]
        public string TipCombustibil { get; set; }
        [Required]
        [Range(2,4)]
        [Display(Name = "Numar usi")]
        public int NumarUsi { get; set; }
        [Required]
        [Display(Name = "Tip cutie viteza")]
        public string TipCutieViteza { get; set; }
        [Required]
        [Range(1,2.5)]
        [Display(Name = "Masa masina")]
        public float MasaTotala { get; set; }
        [Required]
        [Display(Name = "Tarif / zi")]
        public float TarifPeZi { get; set; }
        [Display(Name = "Tarif / saptamana")]
        public float TarifPeSaptamana { get; set; }
        [Display(Name = "Tarif / luna")]
        public float TarifPeLuna { get; set; }

        //Legatura cu tabela MarcaMasina
        [Required]
        [Display(Name ="Marca")]
        public int IdMarca { get; set; }
        [ForeignKey("IdMarca")]
        [ValidateNever]
        public MarcaMasina MarcaMasina { get; set; }

    }
}
