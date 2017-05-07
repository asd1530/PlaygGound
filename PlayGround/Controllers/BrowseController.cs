using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlayGround.Logic;
using Microsoft.AspNetCore.Cors;
using PlayGround.Common.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlayGround.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class BrowseController : BaseController
    {
        private ReportManager reportManager;

        public BrowseController(IServiceProvider provider) : base(provider)
        {
            this.reportManager = provider.GetService<ReportManager>();
        }
        // GET: api/values
        [HttpGet]
        public List<TreeNode<ReportRow>> Get()
        {
            return this.reportManager.GenerateReport();
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
