using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlayGround.Data.Doc;
using PlayGround.Data.Entity;
using PlayGround.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlayGround.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class ValuesController : BaseController
    {
        private ImportManager importManager;

        public ValuesController(IServiceProvider provider) : base(provider)
        {
            this.importManager = provider.GetService<ImportManager>();
        }

        // GET api/values
        [HttpGet]
        public IList<Imports> Get()
        {
            ImportData id = new ImportData()
            {
                Id = 0,
                Name = "Test",
                Description = "Test asjdhkash dsa"
            };
            importManager.SaveDocs(id);
            return importManager.GetAll();

            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> Post(ICollection<IFormFile> files)
        {
            var stream = files.First().OpenReadStream();
            var name = files.First().FileName;

            return new OkObjectResult("Success");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
