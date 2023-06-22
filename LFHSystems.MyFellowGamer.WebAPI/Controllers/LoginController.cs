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
    public class LoginController : Controller
    {
        IConfiguration _configuration;
        readonly UserRepository repo;
        readonly MyDbContext _ctx;
        public LoginController(IConfiguration configuration, MyDbContext ctx)
        {
            _configuration = configuration;
            this._ctx = ctx;

            repo = new UserRepository(_configuration, _ctx);
        }

        [HttpPost]
        [Route("Insert")]
        public JsonResult Insert([FromBody] UserModel pUser)
        {
            pUser.CreationDate = DateTime.Now;
            repo.Insert(ref pUser);

            return Json(pUser);
        }

        [HttpGet]
        [Route("GetUserByEmail/{pEmail}")]
        public JsonResult GetUserByEmail(string pEmail)
        {
            UserModel ret = repo.GetByParameter(new UserModel() { Email = pEmail });

            return Json(ret);
        }

        [HttpGet]
        [Route("GetUserByUsername/{pUsername}")]
        public JsonResult GetUserByUsername(string pUsername)
        {
            UserModel ret = repo.GetByParameter(new UserModel() { Username = pUsername });

            return Json(ret);
        }


        [HttpGet]
        [Route("GetUserForLogin/{pObj}")]
        public UserModel GetUserForLogin(string pObj)
        {
            UserModel ret;

            UserModel param = pObj.DeserializeFromJson<UserModel>();
            ret = repo.GetByParameter(param);
            return ret;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public UserModel GetUserById(int id)
        {
            IEnumerable<UserModel> ret = new List<UserModel>();
                        
            return ret.Where(a => a.ID == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            IEnumerable<UserModel> ret = new List<UserModel>();            

            return ret;
        }                
    }
}
