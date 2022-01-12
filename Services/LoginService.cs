using Microsoft.AspNetCore.Http;
using SignUpSignInAspNetCore.Interfaces;
using SignUpSignInAspNetCore.Models;

namespace SignUpSignInAspNetCore.Services
{
    public class LoginService
    {
        private IRepository<User> _userRepository;
        private IHttpContextAccessor _accessor;
        public LoginService(IRepository<User> userRepository, IHttpContextAccessor accessor)
        {
            _userRepository = userRepository;
            _accessor = accessor;
        }
        public bool IsExist(string username)
        {
            User user = _userRepository.SearchOne(u => u.UserName == username);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Login(string uname, string pwd)
        {
            User u = _userRepository.SearchOne(user => user.UserName == uname && user.Password == pwd);
            if (u != null)
            {
                _accessor.HttpContext.Session.SetString("isLogged", "true");
                _accessor.HttpContext.Session.SetString("username", uname);
                return true;
            }
            return false;
        }
        public bool IsLogged()
        {
            if (bool.TryParse(_accessor.HttpContext.Session.GetString("isLogged"), out bool isLogged))
            {
                if(isLogged)
                {
                    return true;
                }
            }
            return false;
        }
        public string GetUser()
        {
            string findUser =_accessor.HttpContext.Session.GetString("username");
            return findUser;
        }
        public bool Logout()
        {
            _accessor.HttpContext.Session.Clear();
            if (_accessor.HttpContext == null) {
                return true;
            } else return false;
        }
    }
}
