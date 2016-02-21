using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;

namespace UIFramework
{
    public enum EDialogBoxStyle
    {
        OKButton = 0,
        OKCancelButtons = 1,
        YesNoButtons = 2
    }
    public enum EDialogBoxResult
    {
        Undefined = -1,
        OK = 0,
        Cancel = 1,
        Yes = 2,
        No = 3
    }
    public static class DialogBox
    {
        public static async Task<EDialogBoxResult> ShowDialogBoxAsync(string title,string text,EDialogBoxStyle style)
        {
            var dialog = new ContentDialog()
            { Title = title };
            var panel = new StackPanel();
            panel.Children.Add(new TextBlock() {Text=text,TextWrapping=Windows.UI.Xaml.TextWrapping.Wrap });
            dialog.Content = panel;
            EDialogBoxResult res = EDialogBoxResult.Undefined; 

            switch (style)
            {
                case EDialogBoxStyle.OKButton:
                    {
                        dialog.PrimaryButtonText = "OK";
                        dialog.PrimaryButtonClick += (d, o) => { res = EDialogBoxResult.OK; };
                        break;
                    }
                case EDialogBoxStyle.OKCancelButtons:
                    {
                        dialog.PrimaryButtonText = "OK";
                        dialog.PrimaryButtonClick += (d, o) => { res = EDialogBoxResult.OK; };
                        dialog.SecondaryButtonText = "Cancel";
                        dialog.SecondaryButtonClick += (d, o) => { res = EDialogBoxResult.Cancel ; };
                        break;
                    }
                case EDialogBoxStyle.YesNoButtons:
                    {
                        dialog.PrimaryButtonText = "Yes";
                        dialog.PrimaryButtonClick += (d,o) => { res = EDialogBoxResult.Yes; };
                        dialog.SecondaryButtonText = "No";
                        dialog.SecondaryButtonClick += (d, o) => { res = EDialogBoxResult.No; };
                        break;
                    }
            }

            var result = await dialog.ShowAsync();
            Task<EDialogBoxResult> task1 = Task<EDialogBoxResult>.Factory.StartNew(() => res);
            return res;
        }
    }
}
