using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UIFramework.Navigation
{
    public interface INavigationService
    {
        object Parameter { get; }
        event NavigatingCancelEventHandler Navigating;

        void NavigateTo(Type page, object parameter = null);
        void GoBack();
        void Initialized(Frame frame);
    }
}
