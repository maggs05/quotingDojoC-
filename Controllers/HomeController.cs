using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace QuotingDojo1.Controllers{
    public class HomeController: Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            HttpContext.Session.SetString("Name", "name");
            HttpContext.Session.SetString("Quote","quote");
            return View();
        }
        [HttpPost]
        [Route("Quotes")]
        public IActionResult Quotes(){
            string nameVariable = HttpContext.Session.GetString("Name");
            string quoteVariable = HttpContext.Session.GetString("Quote");
            return View("Quotes");
            
        }
        [HttpGet]
        [Route("Quotes")]
        public IActionResult Skip(){
            return View("Quotes");

        }
    }
}