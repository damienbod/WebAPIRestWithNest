using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Damienbod.BusinessLayer.Managers;
using Damienbod.BusinessLayer.Providers;
using Thinktecture.IdentityModel.WebApi;

namespace WebAPIRestWithNest.Controllers
{
   
    public class ExportToExcelController : ApiController
    {
        private readonly IAnimalManager _animalManager;
        private readonly ILogProvider _logProvider;

        public ExportToExcelController(IAnimalManager animalManager, ILogProvider logProvider)
        {
            _animalManager = animalManager;
            _logProvider = logProvider;
        }

        [ResourceActionAuthorize("export")]
        [ScopeAuthorize("export")]
        [Authorize]
        [HttpGet]
        [Route("api/exporttoexcel")]
        public IHttpActionResult GetAnimalsExportExcel(string token)
        { 
            Request.Headers.Accept.Clear();
            Request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.ms-excel"));
            return Ok(_animalManager.GetAnimals());
        }

        [Authorize]
        [HttpGet]
        [Route("api/export")]
        public IHttpActionResult GetAnimalsExport()
        {
            return Ok(_animalManager.GetAnimals());
        }
    }
}
