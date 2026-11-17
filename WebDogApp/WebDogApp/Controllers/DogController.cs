using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebDogApp.Core.Contracts;
using WebDogApp.Infrastructure.Data.Domain;
using WebDogApp.Models.Breed;
using WebDogApp.Models.Dog;

namespace WebDogApp.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogService _dogService;
        private readonly IBreedService _breedService;
        public DogController (IDogService dogsService,  IBreedService breedsService)
        {
            this._dogService = dogsService;
            this._breedService = breedsService;
        }
        // GET: DogController
        public ActionResult Index(string searchStringBreed, string searchStringName)
        {
            List<IndexVM> dogs = _dogService.GetDogs(searchStringBreed, searchStringName).Select(item => new IndexVM
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            }).ToList();

            
            return this.View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DetailsVM dog = new DetailsVM()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            };
            return View(dog);
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            var dog = new CreateVM();
            dog.Breeds = _breedService.GetBreeds().Select(c => new BreedPairViewModel() {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return View(dog);
        }

        // POST: DogController/Create
        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateVM dog)
        {
            if (ModelState.IsValid)
            {
                var createdId = _dogService.Create(
                    dog.Name,
                    dog.Age,
                    dog.BreedId,
                    dog.Picture
                );

                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // GET: DogController/Edit/5
        
        public IActionResult Edit(int id)
        {
            Dog item = _dogService.GetDogById(id);

            if (item == null)
            {
                return NotFound();
            }

            EditVM dog = new EditVM()
            {
                Id = item.Id,
                Name = item.Name,
                BreedId = item.BreedId,
                Age = item.Age,
                Picture = item.Picture
            };

            dog.Breeds = _breedService.GetBreeds()
                .Select(c => new BreedPairViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

            return View(dog);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditVM bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(
                    id,
                    bindingModel.Name,
                    bindingModel.Age,
                    bindingModel.BreedId,
                    bindingModel.Picture
                );

                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }

            return View(bindingModel);
        }

        // GET: DogController/Delete/5
        
        public IActionResult Delete(int id)
        {
            Dog item = _dogService.GetDogById(id);

            if (item == null)
            {
                return NotFound();
            }

            DeleteVM dog = new DeleteVM()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                BreedName = item.Breed.Name,
                Picture = item.Picture
            };

            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
