using AutoMapper;
using LFHSystems.MyFellowGamer.Business;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LFHSystems.MyFellowGamer.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        UserBusiness usrBus;
        public LoginController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;

            usrBus = new UserBusiness(_configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignInViewModel pObj)
        {
            bool loginSuccess = usrBus.AuthenticateUser(_mapper.Map<SignInModel>(pObj));

            if (loginSuccess)
                return RedirectToAction("");

            return View(pObj);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignInUser(SignInViewModel pObj)
        //{
        //    //UserModel ret = usrBus.SignupNewUser(_mapper.Map<UserModel>(pObj));

        //    //pObj = _mapper.Map<UserViewModel>(ret);

        //    return View("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUpUser(UserViewModel pObj)
        {
            try
            {
                UserModel ret = usrBus.SignupNewUser(_mapper.Map<UserModel>(pObj));

                pObj = _mapper.Map<UserViewModel>(ret);

                ViewBag.successMessage = "User signUp success";
                return View("Index");
            }
            catch (System.Exception ex)
            {
                ViewBag.failureMessage = "Failure";

                throw;
            }
        }

        //private void InsertTestUser()
        //{
        //    string username = "Luan_Hora";
        //    string email = "luan-hora@hotmail.com";

        //    UserModel objUsername = new UserModel() { Username = username };
        //    UserViewModel view = _mapper.Map<UserModel, UserViewModel>(objUsername);

        //    Model.UserModel objEmail = new Model.UserModel() { Email = email };

        //    #region test user authentication
        //    string responseUsername = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetUserForLogin/{objUsername.ToJson<Model.UserModel>()}").Result;

        //    string responseEmail = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetUserForLogin/{objEmail.ToJson<Model.UserModel>()}").Result;

        //    Model.UserModel userName = JsonConvert.DeserializeObject<Model.UserModel>(responseUsername);
        //    Model.UserModel userEmail = JsonConvert.DeserializeObject<Model.UserModel>(responseEmail);

        //    string decodedPassword = Encryption.DecodePasswordFromBase64(userName.PIN);

        //    #endregion

        //    //Model.UserModel usr = new Model.UserModel()
        //    //{
        //    //    Username = "Luan_Hora",
        //    //    Email = "luan-hora@hotmail.com",
        //    //    PIN = Encryption.EncodePasswordToBase64("Lu@38537725"),
        //    //    PrivacyPolicy = true,
        //    //    TermsOfUse = false,
        //    //    CreationDate = DateTime.Now
        //    //};

        //    //StringContent content = new StringContent(JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");

        //    //ApiUsage api = new ApiUsage();
        //    //string response = APIConsume.ApiPostAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/Insert", content).Result;
        //    //string response2 = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetUserById/" + 2).Result;
        //    //string response3 = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Login/GetAllUsers").Result;

        //    //Model.UserModel usr2 = JsonConvert.DeserializeObject<Model.UserModel>(response);
        //    //Model.UserModel usr3 = JsonConvert.DeserializeObject<Model.UserModel>(response2);
        //    //IEnumerable<Model.UserModel> usr4 = JsonConvert.DeserializeObject<List<Model.UserModel>>(response3);
        //}
    }
}
