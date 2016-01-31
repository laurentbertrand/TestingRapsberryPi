using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.ViewModels
{
    public class LoginViewModel
    {
        private User _user;

        public LoginViewModel()
        {
            _user = new User();
            _user.Login = "Laurent";
            _user.Password = "Password";
        }
        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
    }
}
