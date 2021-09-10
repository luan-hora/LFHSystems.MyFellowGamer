using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LFHSystems.MyFellowGamer.WebApp.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult InsertNewGame(UserViewModel pObj)
        //{
        //    UserModel ret = usrBus.SignupNewUser(_mapper.Map<UserModel>(pObj));

        //    pObj = _mapper.Map<UserViewModel>(ret);

        //    return View("Index");
        //}
    }
}
