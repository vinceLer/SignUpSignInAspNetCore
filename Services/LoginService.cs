using SignUpSignInAspNetCore.Interfaces;
using SignUpSignInAspNetCore.Models;

namespace SignUpSignInAspNetCore.Services
{
    public class LoginService
    {
        private IRepository<User> _userRepository;
        public LoginService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
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
                return true;
            }
            return false;
        }
        
    }
}
