using Microsoft.AspNetCore.Mvc;
using SignUpSignInAspNetCore.Interfaces;
using SignUpSignInAspNetCore.Models;
using SignUpSignInAspNetCore.Services;

namespace SignUpSignInAspNetCore.Controllers
{
    public class LoginController : Controller
    {
        private IRepository<User> _userRepository;
        LoginService _loginService;
        public LoginController(IRepository<User> userRepository, LoginService loginService)
        {
            _userRepository = userRepository;
            _loginService = loginService;
        }
        public IActionResult LoginForm(string ErrorSignUp, string ErrorSignIn)
        {
            ViewBag.ErrorSignUp = ErrorSignUp;
            ViewBag.ErrorSignIn = ErrorSignIn;
            return View();
        }
        public IActionResult SubmitSignUpForm(User user, string confirmPassword)
        {
            if(!_loginService.IsExist(user.UserName))
            {
                if(user.Password == confirmPassword)
                {
                    if(_userRepository.Save(user))
                    {
                        _loginService.Login(user.UserName, user.Password);
                        return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToAction("LoginForm", "Login", new { ErrorSignUp = "Password and Confirm Password was differents, they should be the same" } );
            }
            else
            {
                return RedirectToAction("LoginForm", "Login", new {ErrorSignUp = "Username not available, already used by other" });
            }
        }
        public IActionResult SubmitSignInForm(string uName, string pwd)
        {
            if (_loginService.Login(uName, pwd))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("LoginForm", new { ErrorSignIn = "Username or password not valid" });
        }
    }
}
