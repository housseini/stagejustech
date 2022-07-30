using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justch.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            Response.Cookies.Delete("access_token");
            return View();
        }
    }
}
