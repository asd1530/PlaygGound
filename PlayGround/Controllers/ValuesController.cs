using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlayGround.Data.Doc;
using PlayGround.Data.Entity;
using PlayGround.Logic;
using System;
using System.Collections.Generic;

namespace PlayGround.Controllers
{
    [Route("api/[controller]")]
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
