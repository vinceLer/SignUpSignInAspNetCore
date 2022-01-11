using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUpSignInAspNetCore.Models;
using SignUpSignInAspNetCore.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpSignInAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        LoginService _loginService;

        public HomeController(LoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            if (_loginService.IsLogged())
            {
                return View();
            }
            return RedirectToAction("LoginForm", "User");
        }

        public IActionResult Privacy()
        {
            if (_loginService.IsLogged())
            {
                return View();
            }
            return RedirectToAction("LoginForm", "User");
        }
    }
}
