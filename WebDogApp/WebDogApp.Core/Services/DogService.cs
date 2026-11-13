using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebDogApp.Core.Contracts;
using WebDogApp.Infrastructure.Data;
using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Services
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext _context;
        public DogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, int age, int breedId, string picture)
        {
            Dog item = new Dog
            {
                Name = name,
                Age = age,
                BreedId = _context.Breeds.Find(breedId),
                Picture = picture
            };
            _context.Dogs.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Dog GetDogById(int dogID)
        {
            return _context.Dogs.Find(dogID);
        }

        public List<Dog> GetDogs()
        {
            List<Dog> dogs = _context.Dogs.ToList();
            return dogs;
        }

        public List<Dog> GetDogs(string searchStringBreed, string searchStringName)
        {
            List<Dog> dogs = _context.Dogs.ToList();
            if (!String.IsNullOrEmpty(searchStringBreed) && !String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Breed.Name.Contains(searchStringBreed) && d.Name.Contains(searchStringName)).ToList();
            }else if(!String.IsNullOrEmpty(searchStringBreed)){
                dogs = dogs.Where(d => d.Breed.Name.Contains(searchStringBreed)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringName))
            {
                dogs = dogs.Where(d => d.Name.Contains(searchStringName)).ToList();
            }
            return dogs;
        }

        public bool RemoveById(int dogID)
        {
            
        }

        public bool UpdateDog(int dogID, string name, int age, int breedId, string picture)
        {
            throw new NotImplementedException();
        }
    }
}
