using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using WebAPIRestWithNest.Versioning;

namespace WebAPIRestWithNest.Controllers
{
    public class AnimalsV2Controller : ApiController
    {
        private readonly IAnimalManager _animalManager;
        private readonly ILogProvider _logProvider;

        public AnimalsV2Controller(IAnimalManager animalManager, ILogProvider logProvider)
        {
            _animalManager = animalManager;
            _logProvider = logProvider;
        }

        // GET api/animals
        [HttpGet]
        [VersionedRoute("api/animals", 2)]
        public IHttpActionResult Get()
        {
            return SetVersionOk(_animalManager.GetAnimals());

        }

        private IHttpActionResult SetVersionOk(object body)
        {
            return new SetVersionInResponseHeader<object>(Request, "2", body);
        }
    }
}
