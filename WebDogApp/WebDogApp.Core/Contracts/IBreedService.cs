using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Contracts
{
    public interface IBreedService
    {
        List<Breed> GetBreeds();
        Breed GetBreedById(int breedId);
        List<Dog> GetDogByBreed(int breedId);
    }
}
