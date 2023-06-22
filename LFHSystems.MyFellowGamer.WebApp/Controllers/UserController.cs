using AutoMapper;
using LFHSystems.MyFellowGamer.Business;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace LFHSystems.MyFellowGamer.WebApp.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        UserBusiness usrBus;
        public UserController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;

            usrBus = new UserBusiness(_configuration);
        }

        // GET: UserController
        public ActionResult Index()
        {
            List<UserViewModel> lstUsers = new List<UserViewModel>();
            try
            {
                lstUsers = _mapper.Map<List<UserViewModel>>(usrBus.GetExistingUsers(new Model.UserModel() { }));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(lstUsers);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            usrBus.DeleteUser(id);

            return RedirectToAction("Index");
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUpUser(UserViewModel pObj)
        {
            try
            {
                UserModel ret = usrBus.SignupNewUser(_mapper.Map<UserModel>(pObj));

                pObj = _mapper.Map<UserViewModel>(ret);

                ViewBag.successMessage = "User signUp success";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.failureMessage = "Failure";

                throw;
            }
        }
    }
}
