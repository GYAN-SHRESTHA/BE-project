using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Madds.Models;


namespace Madds.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "HSALI Description Page";

            return View();
        }

        public ActionResult Success(Madds.Models.Class1 c)
        {
            int a = Cool(c);
            if(a==0)
            {
                return Index();
            }
            else
            {
                return About();
            }
        }

        public ActionResult Contact()
        {
           
            return View();
        }

        public int Cool(Madds.Models.Class1 c)
        {
            string m = "Sudin";
            string n = c.Name;
            int a = (String.Compare(m,n,true));
            return (a);
        }
    }
}

