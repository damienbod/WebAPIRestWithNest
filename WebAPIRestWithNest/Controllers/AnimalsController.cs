using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Damienbod.BusinessLayer.DomainModel;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using WebAPIRestWithNest.Filters;

namespace WebAPIRestWithNest.Controllers
{
    [RoutePrefix("api/animals")]
    [LoggingFilter]
    [AnimalExceptionFilter]
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
        public IHttpActionResult Get()
        {
            return Ok(_animalManager.GetAnimals());
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
        public IHttpActionResult Post([FromBody]Animal value)
        {
            _animalManager.CreateAnimal(value);
            // could set the Id here in the retrun content
            return Created<Animal>(Request.RequestUri, value );
        }

        // PUT api/animals/5
        [HttpPut]
        [HttpPatch]
        [Route("")]
        public void Put( [FromBody]Animal value)
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
            //_animalManager.DeleteIndex("outofprocessslab-2014.04.11");

            _animalManager.DeleteIndex(index);
        }
    }
}
