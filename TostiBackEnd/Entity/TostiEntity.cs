using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TostiBusinessEntities;

namespace TostiBackEnd.Entity
{
    public class TostiEntity
    {
        public TostiEntity() { }

        public TostiEntity(Tosti tosti)
        {
            Id = tosti.Id;
            Naam = tosti.Naam;
            Brood = tosti.Brood;
            Vulling = tosti.Vulling;
            Calorieen = tosti.Calorieen;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:100, MinimumLength = 3, ErrorMessage = "Lengte van naam mag maximaal 100 en minimaal 3 tekens zijn.")]
        public string Naam { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Lengte van brood mag maximaal 100 en minimaal 3 tekens zijn.")]
        public string Brood { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Lengte van naam mag maximaal 100 en minimaal 3 tekens zijn.")]
        public string Vulling { get; set; }

        [Required]
        [Range(minimum:1, maximum:10000, ErrorMessage = "Calorieen moet een waarde hebben tussen de 1 en 10000.")]
        public int Calorieen { get; set; }

        public Tosti ToDto()
        {
            return new Tosti(Id, Naam, Brood, Vulling, Calorieen);
        }
    }
}
