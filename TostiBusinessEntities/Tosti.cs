using System;
using System.ComponentModel.DataAnnotations;

namespace TostiBusinessEntities
{
    public class Tosti
    {
        public Tosti()
        {

        }

        public Tosti(int id, string naam, string brood, string vulling, int calorieen)
        {
            Id = id;
            Naam = naam;
            Brood = brood;
            Vulling = vulling;
            Calorieen = calorieen;
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Lengte van naam mag maximaal 100 en minimaal 3 tekens zijn.")]
        public string Naam { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Lengte van brood mag maximaal 100 en minimaal 3 tekens zijn.")]
        public string Brood { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Lengte van naam mag maximaal 100 en minimaal 3 tekens zijn.")]
        public string Vulling { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 10000, ErrorMessage = "Calorieen moet een waarde hebben tussen de 1 en 10000.")]
        public int Calorieen { get; set; }
    }
}
