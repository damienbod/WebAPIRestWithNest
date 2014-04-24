using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Damienbod.BusinessLayer.DomainModel;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using Microsoft.Ajax.Utilities;
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
        [System.Web.Http.HttpGet]
        [VersionedRoute("api/animals", 2)]
        [ResponseType(typeof(IEnumerable<Animal>))]
        public IHttpActionResult Get()
        {
            return SetVersionOk(_animalManager.GetAnimals());
        }

        private IHttpActionResult SetVersionOk(IEnumerable<Animal> body)
        {
            return new SetVersionInResponseHeader<IEnumerable<Animal>>(Request, "2", body);
        }
    }
}
