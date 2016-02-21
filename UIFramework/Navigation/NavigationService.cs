using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UIFramework.Navigation
{
    public class NavigationService : INavigationService
    {

        public event NavigatingCancelEventHandler Navigating;

        private Frame frame;
        public object Parameter
        {
            get;
            private set;
        }

        public void NavigateTo(Type page, object parameter = null)
        {
            if (null != parameter)
            {
                Parameter = parameter;
                frame.Navigate(page, parameter);
            }
            else
            {
                Parameter = null;
                frame.Navigate(page);
            }
        }

        public void GoBack()
        {
            if (EnsureMainFrame() && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public void Initialized(Frame frame)
        {
            if (null == frame)
            {
                throw new ArgumentNullException();
            }

            if (null != frame)
            {
                frame.Navigating -= FrameNavigating;
            }
            this.frame = frame;
            this.frame.Navigating += FrameNavigating;
        }

        private bool EnsureMainFrame()
        {
            return null != frame;
        }

        private void FrameNavigating(object sender, NavigatingCancelEventArgs e)
        {
            if (null != Navigating)
                Navigating(this, e);
        }
    }
}
