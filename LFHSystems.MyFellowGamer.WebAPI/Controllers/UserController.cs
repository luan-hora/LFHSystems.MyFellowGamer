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
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IConfiguration _configuration;
        UserRepository repo;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;

            repo = new UserRepository(_configuration);
        }

        [HttpGet]
        [Route("GetExistingUsers")]
        public JsonResult GetExistingUsers()
        {
            List<UserModel> ret = null;
            ret = repo.GetAll()?.ToList();

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
