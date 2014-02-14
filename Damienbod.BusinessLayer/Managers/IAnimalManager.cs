using System.Collections.Generic;
using System.Threading.Tasks;
using Damienbod.BusinessLayer.DomainModel;

namespace Damienbod.BusinessLayer.Managers
{
    public interface IAnimalManager
    {
        Task Create(Animal animal);

        Task Delete(int id);

        Task<IEnumerable<Animal>> Get();

        Task<Animal> Get(int id);

        Task Update(Animal animal);
    }
}
