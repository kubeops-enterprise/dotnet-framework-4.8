﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNetFrame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var check = ConfigurationManager.AppSettings.GetValues("kubeexuser").FirstOrDefault();
            ViewBag.CheckConf = !string.IsNullOrEmpty(check);

            return View();
        }
    }
}
