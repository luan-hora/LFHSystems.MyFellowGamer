using AutoMapper;
using LFHSystems.MyFellowGamer.Business;
using LFHSystems.MyFellowGamer.Model;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using LFHSystems.MyFellowGamer.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace LFHSystems.MyFellowGamer.WebApp.Controllers
{
    public class PublisherController : Controller
    {
        private IConfiguration _configuration;
        private readonly IMapper _mapper;

        PublisherBusiness usrPub;
        public PublisherController(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;

            usrPub = new PublisherBusiness(_configuration);
        }

        // GET: PublisherController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<PublisherViewModel> lstPublishers = new List<PublisherViewModel>();
            try
            {
                lstPublishers = _mapper.Map<List<PublisherViewModel>>(usrPub.GetExistingPublishers(new Model.PublisherModel() { }));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View(lstPublishers);
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }
        //[BindProperty]
        //public string Name { get; set; }


        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] PublisherViewModel pObj)
        {
            try
            {
                PublisherModel ret = usrPub.CreateNewPublisher(_mapper.Map<PublisherModel>(pObj));

                pObj = _mapper.Map<PublisherViewModel>(ret);

                ViewBag.successMessage = "Success";
                //return View("Index");
                return Content(ret.ToJson());
            }
            catch
            {
                ViewBag.failureMessage = "Failure";
                return View("Index");
            }
        }

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublisherController/Edit/5
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

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        // POST: PublisherController/Delete/5
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
    }
}
