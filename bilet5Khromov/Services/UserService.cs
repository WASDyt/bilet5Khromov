using bilet5Khromov.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilet5Khromov.Services
{
    public class UserService
    {
        public Users Authenticate(string logins, string passwords)
        {
            using (var context = new bilet5KhromovEntities())
            {
                return context.Users.FirstOrDefault(u => u.login == logins && u.password == passwords);
            }
        }
    }
}
