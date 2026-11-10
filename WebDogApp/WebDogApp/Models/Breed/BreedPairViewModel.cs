using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.Breed
{
    public class BreedPairViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Breed")]
        public string Name { get; set; } = null!;
    }
}
