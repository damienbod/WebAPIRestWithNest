using System.Collections.Generic;
using Damienbod.BusinessLayer.Attributes;
using Damienbod.BusinessLayer.DomainModel;
using Damienbod.BusinessLayer.Providers;

namespace Damienbod.ElasticSearchProvider
{
    [TransientLifetime]
    public class SearchProvider : ISearchProvider
    {
        private readonly ILogProvider _logProvider;

        SearchProvider(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public void UpdateCreateAnimal(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return new List<Animal> { new Animal { AnimalType = "Dog", Id = 1 }, new Animal { AnimalType = "Cat", Id = 2 } };
        }
    }
}
