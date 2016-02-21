using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;
using UIFramework;
using System.Windows.Input;
using UIFramework.Navigation;

namespace Model.ViewModels
{
    public class LoginViewModel
    {
        private User _user;

        private DelegateCommand validateLogin;
        public LoginViewModel()
        {
            validateLogin = new DelegateCommand(Login);
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

        public ICommand ValidateLogin
        {
            get
            {
                return this.validateLogin;
            }
        }


        private async void Login (object t)
        {
            if (User.Login == "Laurent" && User.Password == "1234")
            {
                ViewService.Service.NavigationService.NavigateTo(ViewService.Service.GetView("MainView"), 15);
            }
            else
            {
                if (await DialogBox.ShowDialogBoxAsync("title", "textbutton", EDialogBoxStyle.OKCancelButtons) == EDialogBoxResult.OK)
                {
                    return;
                };
            }
        }
    }
}
