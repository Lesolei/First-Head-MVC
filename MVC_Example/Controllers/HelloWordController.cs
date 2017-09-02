using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Example.Controllers
{
    public class HelloWordController : Controller
    {
        public ActionResult index()
        {
            return View();
        }
        // GET: HelloWord
        //public string Index()
        //{
        //    return "This is my <b>default</b> action!";
        //}
        /// <summary>
        /// get welcome
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome(string name,int NumTimes = 1)
        {
            ViewBag.Message = name;
            ViewBag.NumTimes = NumTimes;
            return View();
        }
    }
}