﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesWebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}