using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ControlCenter
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;  // enable custom titlebar
            NavBar.SelectedItem = NavBar.MenuItems[0]; // Set Home as the selected item
            ContentFrame.Navigate(typeof(HomePage), null, new EntranceNavigationTransitionInfo()); // Navigate to HomePage by default with transition
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer != null)
            {
                switch (args.SelectedItemContainer.Tag.ToString())
                {
                    case "Home":
                        ContentFrame.Navigate(typeof(HomePage), null, new EntranceNavigationTransitionInfo());
                        break;
                    case "Vault":
                        ContentFrame.Navigate(typeof(VaultPage), null, new EntranceNavigationTransitionInfo());
                        break;
                    case "Accounts":
                        ContentFrame.Navigate(typeof(AccountsPage), null, new EntranceNavigationTransitionInfo());
                        break;
                    case "Browser":
                        ContentFrame.Navigate(typeof(BrowserPage), null, new EntranceNavigationTransitionInfo());
                        break;
                    case "Settings":
                        ContentFrame.Navigate(typeof(SettingsPage), null, new EntranceNavigationTransitionInfo());
                        break;
                    case "Help":
                        ContentFrame.Navigate(typeof(HelpPage), null, new EntranceNavigationTransitionInfo());
                        break;
                }
            }
        }
    }
}
