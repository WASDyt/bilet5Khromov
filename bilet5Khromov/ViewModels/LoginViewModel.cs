using bilet5Khromov.BD;
using bilet5Khromov.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilet5Khromov.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        public UserService _userService;
        public string login { get; set; }
        public string password { get; set; }
        public Users AuthenticatedUser { get; private set; }

        public LoginViewModel()
        {
            _userService = new UserService();
        }

        public bool Authenticate()
        {
            AuthenticatedUser = _userService.Authenticate(login, password);
            return AuthenticatedUser != null;
        }
    }
}
