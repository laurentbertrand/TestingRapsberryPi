using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFramework.Navigation
{
    public class ViewService
    {
        private IDictionary<string, Type> _viewRegistered;

        private static ViewService _instance;
        public static ViewService Service
        {
            get
            {
                return _instance ?? (_instance = new ViewService());
            }
        }

        private ViewService()
        {
            _viewRegistered = new Dictionary<string, Type>();
        }

        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        public void RegisterView(string navigationStringValue, Type typeOfView)
        {
            if (!_viewRegistered.ContainsKey(navigationStringValue))
                _viewRegistered.Add(new KeyValuePair<string, Type>(navigationStringValue, typeOfView));
        }

        public Type GetView(string navigationStringValue)
        {
            if (string.IsNullOrWhiteSpace(navigationStringValue))
            {
                throw new ArgumentNullException();
            }

            if (!_viewRegistered.Any())
            {
                return null;
            }

            if (!_viewRegistered.ContainsKey(navigationStringValue))
            {
                throw new ArgumentOutOfRangeException();
            }

            return _viewRegistered[navigationStringValue];
        }
    }
}
