using AutoMapper;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Repository;
using LFHSystems.MyFellowGamer.Utils.API;
using LFHSystems.MyFellowGamer.Utils.Cryptography;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using LFHSystems.MyFellowGamer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly IMapper _mapper;
        public LoginController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            InsertTestUser();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[Route("CreateUser")]
        //public JsonResult CreateUser(string pObj)
        public JsonResult CreateUser(UserViewModel pObj)
        {
            try
            {
                int x;

                if (!ModelState.IsValid)
                    x = ModelState.ErrorCount;

                UserModel ret = null;

                return Json(ret);
            }
            catch (WebException ex)
            {
                return Json(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertTestUser()
        {
            string username = "Luan_Hora";
            string email = "luan-hora@hotmail.com";

            UserModel objUsername = new UserModel() { Username = username };
            UserViewModel view = _mapper.Map<UserModel, UserViewModel>(objUsername);

            Model.UserModel objEmail = new Model.UserModel() { Email = email };

            #region test user authentication
            string responseUsername = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetUserForLogin/{objUsername.ToJson<Model.UserModel>()}").Result;

            string responseEmail = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetUserForLogin/{objEmail.ToJson<Model.UserModel>()}").Result;

            Model.UserModel userName = JsonConvert.DeserializeObject<Model.UserModel>(responseUsername);
            Model.UserModel userEmail = JsonConvert.DeserializeObject<Model.UserModel>(responseEmail);

            string decodedPassword = Encryption.DecodePasswordFromBase64(userName.PIN);

            #endregion

            //Model.UserModel usr = new Model.UserModel()
            //{
            //    Username = "Luan_Hora",
            //    Email = "luan-hora@hotmail.com",
            //    PIN = Encryption.EncodePasswordToBase64("Lu@38537725"),
            //    PrivacyPolicy = true,
            //    TermsOfUse = false,
            //    CreationDate = DateTime.Now
            //};

            //StringContent content = new StringContent(JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");

            //ApiUsage api = new ApiUsage();
            //string response = APIConsume.ApiPostAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/Insert", content).Result;
            //string response2 = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetUserById/" + 2).Result;
            //string response3 = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetAllUsers").Result;

            //Model.UserModel usr2 = JsonConvert.DeserializeObject<Model.UserModel>(response);
            //Model.UserModel usr3 = JsonConvert.DeserializeObject<Model.UserModel>(response2);
            //IEnumerable<Model.UserModel> usr4 = JsonConvert.DeserializeObject<List<Model.UserModel>>(response3);
        }
    }
}
