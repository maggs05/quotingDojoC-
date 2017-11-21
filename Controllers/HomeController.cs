using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DbConnection;

namespace QuotingDojo1.Controllers{
    public class HomeController: Controller{
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            if(TempData["Error"]!=null){
                ViewBag.Error=TempData["Error"];
            }
            return View();
        }
        [HttpPost]
        [Route("/Quotes")]
        public IActionResult Create(string name, string quote){
            if(name ==""||quote==""){
                TempData["Error"]="Both fields must be completed!";
                return RedirectToAction("Index");
            }
            string query =$"INSERT INTO quotes (quote, name, created_at, updated_at) VALUES ('{quote}','{name}',NOW(),NOW());";
            DbConnector.Execute(query);           
            return RedirectToAction("Quotes");
            
        }
        [HttpGet]
        [Route("/Quotes")]
        public IActionResult Quotes(){
            return View("Quotes");

        }
    }
}