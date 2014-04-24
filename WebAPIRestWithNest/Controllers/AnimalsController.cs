using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;
using Damienbod.BusinessLayer.DomainModel;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using WebAPIRestWithNest.Filters;
using WebAPIRestWithNest.Versioning;

namespace WebAPIRestWithNest.Controllers
{
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
        [VersionedRoute("api/animals", 1)]
        [ResponseType(typeof(IEnumerable<Animal>))]
        public IHttpActionResult Get()
        {
            return SetVersionOk(_animalManager.GetAnimals());
        }

        [HttpGet]
        [Route("api/animals/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_animalManager.GetAnimal(id));
            }
            catch
            {
                return NotFound();
            }                      
        }

        // POST api/animals
        [HttpPost]
        [Route("api/animals")]
        public IHttpActionResult Post([FromBody]Animal value)
        {
            _animalManager.CreateAnimal(value);
            // could set the Id here in the retrun content
            return Created<Animal>(Request.RequestUri, value);
        }

        // PUT api/animals/5
        [HttpPut]
        [HttpPatch]
        [Route("api/animals")]
        public void Put( [FromBody]Animal value)
        {
            _animalManager.UpdateAnimal(value);
        }

        // DELETE api/animals/5
        [HttpDelete]
        [Route("api/animals/{id}")]
        public void Delete(int id)
        {
            _animalManager.DeleteAnimal(id);
        }

        // DELETE api/animals/5
        [HttpDelete]
        [Route("api/animals/deleteIndex/{index}")]
        public void DeleteIndex(string index)
        {
            _animalManager.DeleteIndex("outofprocessslab-2014.04.19");
            _animalManager.DeleteIndex(index);
        }

        private IHttpActionResult SetVersionOk(IEnumerable<Animal> body)
        {
            return new SetVersionInResponseHeader<IEnumerable<Animal>>(Request, "1", body, true);
        }
    }
}
