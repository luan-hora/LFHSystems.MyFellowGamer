using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace LFHSystems.MyFellowGamer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : Controller
    {
        readonly PublisherRepository repo;
        readonly MyDbContext ctx;
        public PublisherController(IConfiguration configuration, MyDbContext context)
        {
            this.ctx = context;
            repo = new PublisherRepository(configuration, ctx);
        }

        [HttpPost]
        [Route("Insert")]
        public JsonResult Insert([FromBody] PublisherModel pPublisher)
        {
            pPublisher.CreationDate = DateTime.Now;
            repo.Insert_EFCore(ref pPublisher);

            return Json(pPublisher);
        }

        [HttpPost]
        [Route("Update")]
        public JsonResult Update([FromBody] PublisherModel pPublisher)
        {
            pPublisher.CreationDate = DateTime.Now; //Add an update date later (Maybe)
            repo.Update_EFCore(pPublisher);

            return Json(pPublisher);
        }

        [HttpGet]
        [Route("DeleteUser/{pId}")]
        public JsonResult DeleteUser(int pId)
        {
            int ret = 0;
            repo.Delete_EFCore(new PublisherModel() { ID = pId });

            return Json(ret);
        }

        [HttpGet]
        [Route("GetExistingPublishers")]
        public JsonResult GetExistingUsers()
        {
            IEnumerable<PublisherModel> ret;
            ret = repo.GetAll_EFCore();

            return Json(ret);
        }
    }
}
