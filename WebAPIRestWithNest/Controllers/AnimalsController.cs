using System.Collections.Generic;
using System.Web.Http;
using BusinessLayer.DomainModel;

namespace WebAPIRestWithNest.Controllers
{
    [RoutePrefix("api/animals")]
    public class AnimalsController : ApiController
    {
        // GET api/animals
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return new List<Animal>{ new Animal { AnimalType = "Dog", Id = 1 }, new Animal { AnimalType = "Cat", Id = 2 } };
        }

        [HttpGet]
        [Route("{id}")]
        public Animal Get(int id)
        {
            return new Animal{ AnimalType = "Dog", Id = 1 };
        }

        // POST api/animals
        [HttpPost]
        [Route("")]
        public void Post([FromBody]Animal value)
        {
        }

        // PUT api/animals/5
        [HttpPut]
        [Route("{id}")]
        public void Put(int id, [FromBody]Animal value)
        {
        }

        // DELETE api/animals/5
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}
