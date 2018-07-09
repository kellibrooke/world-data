using Microsoft.AspNetCore.Mvc;
using World.Models;
using System.Collections.Generic;
using System;

namespace World.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View(Country.GetAll());
        }

        [HttpGet("/filter")]
        public ActionResult FilterPage()
        {
            return View();
        }

       [HttpPost("/filter")]
        public ActionResult FilterCreate()
        {
            string sortField = Request.Form["sortField : selected"];
            string sortType = Request.Form["sortType : selected"];
            return View(Country.GetSort(sortField, sortType));
        }
    }
}
