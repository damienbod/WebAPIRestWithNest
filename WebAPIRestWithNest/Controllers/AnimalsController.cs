using System.Collections.Generic;
using System.Web.Http;
using Damienbod.BusinessLayer.DomainModel;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using WebAPIRestWithNest.Filters;

namespace WebAPIRestWithNest.Controllers
{
    [RoutePrefix("api/animals")]
    [LoggingFilter]
    public class AnimalsController : ApiController
    {
        private readonly IAnimalManager _animalManager;
        private readonly ILogProvider _logProvider;

        public AnimalsController(IAnimalManager animalManager, ILogProvider logProvider)
        {
            _animalManager = animalManager;
            _logProvider = logProvider;
        }

        // GET api/animals
        [HttpGet]
        [Route("")]
        public IEnumerable<Animal> Get()
        {
            return _animalManager.GetAnimals();
        }

        [HttpGet]
        [Route("{id}")]
        public Animal Get(int id)
        {
            return _animalManager.GetAnimal(id);
           
        }

        // POST api/animals
        [HttpPost]
        [Route("")]
        public void Post([FromBody]Animal value)
        {
            _animalManager.CreateAnimal(value);
        }

        // PUT api/animals/5
        [HttpPut]
        [HttpPatch]
        [Route("{id}")]
        public void Put(int id, [FromBody]Animal value)
        {
            _animalManager.UpdateAnimal(value);
        }

        // DELETE api/animals/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _animalManager.DeleteAnimal(id);
        }

        // DELETE api/animals/5
        [HttpDelete]
        [Route("deleteIndex/{index}")]
        public void DeleteIndex(string index)
        {
            _animalManager.DeleteIndex(index);
        }
    }
}
