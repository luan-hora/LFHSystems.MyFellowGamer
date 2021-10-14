﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using LFHSystems.MyFellowGamer.Business;
using LFHSystems.MyFellowGamer.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LFHSystems.MyFellowGamer.Model;

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

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] PublisherViewModel pObj)
        {
            try
            {
                PublisherModel ret = usrPub.CreateNewPublisher(_mapper.Map<PublisherModel>(pObj));

                pObj = _mapper.Map<PublisherViewModel>(ret);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
            return View();
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
