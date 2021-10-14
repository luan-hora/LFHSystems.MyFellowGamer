//using LFHSystems.MyFellowGamer.Model;
//using LFHSystems.MyFellowGamer.Repository;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using LFHSystems.MyFellowGamer.Business;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Repository;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        IConfiguration _configuration;
        PublisherRepository repo;
        public PublisherController(IConfiguration configuration)
        {
            _configuration = configuration;

            repo = new PublisherRepository(_configuration);
        }

        [HttpPost]
        [Route("Insert")]
        //public async Task<ActionResult<PublisherModel>> Insert([FromBody] PublisherModel pPublisher)
        public JsonResult Insert([FromBody] PublisherModel pPublisher)
        {
            pPublisher.CreationDate = DateTime.Now;
            repo.Insert(ref pPublisher);

            return Json(pPublisher);
        }

        //// GET: api/<PublisherController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<PublisherController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<PublisherController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PublisherController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PublisherController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
