using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : INotifyPropertyChanged
    {
        private string m_Login;
        public string Login
        {
            get
            {
                return m_Login;
            }

            set
            {
                m_Login = value;
                RaisePropertyChanged();
            }
        }

        private string m_Password;
        public string Password
        {
            get
            {
                return m_Password;
            }

            set
            {
                m_Password = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
