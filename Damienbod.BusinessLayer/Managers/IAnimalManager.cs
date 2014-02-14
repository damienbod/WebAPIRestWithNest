using System.Collections.Generic;
using System.Threading.Tasks;
using Damienbod.BusinessLayer.DomainModel;

namespace Damienbod.BusinessLayer.Managers
{
    public interface IAnimalManager
    {
        void Create(Animal animal);

        void Delete(int id);

        Task<IEnumerable<Animal>> Get();

        Task<Animal> Get(int id);

        void Update(Animal animal);
    }
}
