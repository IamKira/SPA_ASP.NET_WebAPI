using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPAforTest.Models;

namespace SPAforTest.Controllers
{
    public class HomeController : Controller
    {
        UserRepository repository = UserRepository.Current;
        public ViewResult Index()
        {            
            return View();
        }
    }
}