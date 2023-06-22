using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace LFHSystems.MyFellowGamer.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        readonly UserRepository repo;
        readonly MyDbContext _ctx;
        public UserController(IConfiguration config, MyDbContext context)
        {
            _ctx = context;
            repo = new UserRepository(config, _ctx);
        }

        [HttpGet]
        [Route("GetExistingUsers")]
        public JsonResult GetExistingUsers()
        {
            IEnumerable<UserModel> ret;
            ret = repo.GetAll_EFCore();

            return Json(ret);
        }

        [HttpGet]
        [Route("DeleteUser/{pId}")]
        public JsonResult DeleteUser(int pId)
        {
            int ret = 0;
            repo.Delete(new UserModel() { ID = pId });

            return Json(ret);
        }
    }
}
