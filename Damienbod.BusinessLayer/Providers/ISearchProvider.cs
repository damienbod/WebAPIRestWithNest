using System.Collections.Generic;
using Damienbod.BusinessLayer.DomainModel;

namespace Damienbod.BusinessLayer.Providers
{
    public interface ISearchProvider
    {
        void UpdateCreateAnimal(Animal animal);

        IEnumerable<Animal> GetAnimals();
    }
}
