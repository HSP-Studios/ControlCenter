using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ControlCenter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public string GreetingText { get; set; } = string.Empty;

        public HomePage()
        {
            this.InitializeComponent();
            SetGreetingText();
        }

        private void SetGreetingText()
        {
            var hour = DateTime.Now.Hour;
            if (hour < 12)
            {
                GreetingText = "Good Morning.";
            }
            else if (hour < 18)
            {
                GreetingText = "Good Afternoon.";
            }
            else
            {
                GreetingText = "Good Evening.";
            }
        }
    }
}
