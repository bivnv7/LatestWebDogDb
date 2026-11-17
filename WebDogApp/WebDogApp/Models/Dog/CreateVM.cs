using System.ComponentModel.DataAnnotations;

using WebDogApp.Models.Breed;

namespace WebDogApp.Models.Dog
{
    public class CreateVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Dog Name")]
        public string Name { get; set; } = null!;
        [Range(0, 30, ErrorMessage = "Age must be between 0 and 30.")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Breed")]
        public int BreedId { get; set; }
        [Display(Name = "Dog Picture")]
        public string Picture { get; set; } = null!;
        public virtual List<BreedPairViewModel> Breeds { get; set; } = new List<BreedPairViewModel>();
    }
}
