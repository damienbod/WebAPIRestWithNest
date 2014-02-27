using System.Collections.Generic;
using Damienbod.BusinessLayer.Attributes;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using Damienbod.BusinessLayer.DomainModel;

namespace BusinessLayer.Managers
{
    [TransientLifetime]
    public class AnimalManager : IAnimalManager
    {
        private readonly ILogProvider _logProvider;
        private ISearchProvider _searchProvider;

        public AnimalManager(ILogProvider logProvider, ISearchProvider searchProvider)
        {
            _logProvider = logProvider;
            _searchProvider = searchProvider;
            _logProvider.BusinessLayerVerbose("created animal manager instance");
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _searchProvider.GetAnimals();
        }

        public Animal GetAnimal(int id)
        {
            return new Animal { AnimalType = "Dog", Id = 1 };
        }

        public void UpdateAnimal(Animal value)
        {
            _searchProvider.UpdateAnimal(value);
        }

        public void DeleteAnimal(int id)
        {
            _searchProvider.DeleteById(id);
        }

        public void CreateAnimal(Animal value)
        {
            _searchProvider.CreateAnimal(value);
        }
    }
}
