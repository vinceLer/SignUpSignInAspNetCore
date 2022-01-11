using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignUpSignInAspNetCore.Interfaces;
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
        private IRepository<User> _userRepository;

        public HomeController(LoginService loginService, IRepository<User> userRepository)
        {
            _loginService = loginService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            if (_loginService.IsLogged())
            {
                ViewBag.LoginService = _loginService.GetUser();
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
