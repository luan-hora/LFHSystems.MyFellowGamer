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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        ServiceCollection _services;
        PublisherRepository repo;
        MyDbContext ctx;
        public PublisherController(IConfiguration configuration, MyDbContext ctx = null)
        {
            _configuration = configuration;
            //this.ctx = ctx ?? GetInMemoryDBContext();
            this.ctx = ctx ?? ConfigureDbContextManually();
            repo = new PublisherRepository(_configuration, ctx);
        }

        //protected MyContext ctx;
        //public BaseTest(MyContext ctx = null)
        //{
        //    this.ctx = ctx ?? GetInMemoryDBContext();
        //}

        protected MyDbContext ConfigureDbContextManually()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            var options = builder.UseSqlServer(_configuration.GetConnectionString("MyFellowGamerConnString")).UseInternalServiceProvider(serviceProvider).Options;
            MyDbContext dbContext = new MyDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
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
