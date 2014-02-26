using System.Collections.Generic;
using Damienbod.BusinessLayer.DomainModel;

namespace Damienbod.BusinessLayer.Providers
{
    public interface ISearchProvider
    {
        void CreateAnimal(Animal animal);

        void UpdateAnimal(Animal animal);

        IEnumerable<Animal> GetAnimals();
    }
}
