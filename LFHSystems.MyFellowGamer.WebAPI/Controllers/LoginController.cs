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
        UserRepository repo;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;

            repo = new UserRepository(_configuration);
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
        [Route("GetUserForLogin/{pObj}")]
        public UserModel GetUserForLogin(string pObj)
        {
            UserModel ret = null;
            UserRepository repo = new UserRepository(_configuration);

            UserModel param = pObj.DeserializeFromJson<UserModel>();
            ret = repo.GetByParameter(param);
            return ret;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public UserModel GetUserById(int id)
        {
            IEnumerable<UserModel> ret = new List<UserModel>();

            ret = PrepareMockUserList();
            return ret.Where(a => a.ID == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            IEnumerable<UserModel> ret = new List<UserModel>();
            ret = PrepareMockUserList();

            return ret;
        }

        #region Teste

        private IEnumerable<UserModel> PrepareMockUserList()
        {
            List<UserModel> ret = new List<UserModel>();
            ret.Add(new UserModel() { ID = 1 });
            ret.Add(new UserModel() { ID = 2 });
            ret.Add(new UserModel() { ID = 3 });

            return ret;
        }

        #endregion 
    }
}
