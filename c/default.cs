using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mercury.model;
using mercury.business;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mercury.controller
{
    public class ctrl_default : Controller
    {
        

        [HttpGet]
        [Route("/example")]
        public IActionResult attachment_get(string id)
        {
            string data = "";
            return Content("404");

        }
        
        [Route("{*url}")]
        public IActionResult error(string code)
        {
            return Content("What are you looking for? Heh!");
        }
    }
}