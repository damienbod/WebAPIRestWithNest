using System.Collections.Generic;
using Damienbod.BusinessLayer.DomainModel;

namespace Damienbod.BusinessLayer.Managers
{
    public interface IAnimalManager
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimal(int id);
        void UpdateAnimal(Animal value);
        void DeleteAnimal(int id);
        void CreateAnimal(Animal value);
        void DeleteIndex(string index);
    }
}
