using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.DomainModel;
using BusinessLayer.Providers;

namespace BusinessLayer.Managers
{
    public class AnimalManager : IAnimalManager
    {
        private readonly ILogProvider _logProvider;

        public AnimalManager(ILogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        public void Create(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Animal>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Animal> Get(string type, int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Animal> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        Task IAnimalManager.Create(Animal animal)
        {
            throw new System.NotImplementedException();
        }
    }
}
