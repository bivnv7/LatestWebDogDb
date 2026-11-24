using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebDogApp.Infrastructure.Data.Domain;

namespace WebDogApp.Core.Contracts
{
    public interface IDogService
    {
        bool Create(string name, int age, int breedId, string picture, string description);
        bool UpdateDog(int dogID, string name, int age, int breedId, string picture, string description);
        List<Dog> GetDogs();
        Dog GetDogById(int dogID);
        bool RemoveById(int dogID);
        List<Dog> GetDogs(string searchStringBreed, string searchStringName, string searchStringAge, string searchStringDescription);
    }
}
