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
using Microsoft.Web.WebView2.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ControlCenter
{
    /// <summary>
    /// Browser page with navigation controls and WebView2 component
    /// </summary>
    public sealed partial class BrowserPage : Page
    {
        private const string DefaultUrl = "https://www.google.com";

        public BrowserPage()
        {
            this.InitializeComponent();
            Loaded += BrowserPage_Loaded;
        }

        private async void BrowserPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize WebView2
            await WebViewControl.EnsureCoreWebView2Async();
            
            // Set default URL
            WebViewControl.Source = new Uri(DefaultUrl);
            UrlBar.Text = DefaultUrl;

            // Set up WebView navigation completed event
            WebViewControl.NavigationCompleted += WebViewControl_NavigationCompleted;
            
            // Update button states
            UpdateNavigationButtonStates();
        }

        private void WebViewControl_NavigationCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            // Update the URL bar with the current URL
            UrlBar.Text = WebViewControl.Source?.ToString() ?? string.Empty;
            
            // Update navigation button states
            UpdateNavigationButtonStates();
        }

        private void UpdateNavigationButtonStates()
        {
            // Update back/forward button states based on navigation history
            BackButton.IsEnabled = WebViewControl.CanGoBack;
            ForwardButton.IsEnabled = WebViewControl.CanGoForward;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (WebViewControl.CanGoBack)
            {
                WebViewControl.GoBack();
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (WebViewControl.CanGoForward)
            {
                WebViewControl.GoForward();
            }
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e)
        {
            WebViewControl.Reload();
        }

        private void UrlBar_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                NavigateToUrl(UrlBar.Text);
                e.Handled = true;
            }
        }

        private void PopupUrlBar_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                NavigateToUrl(PopupUrlBar.Text);
                e.Handled = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Escape)
            {
                e.Handled = true;
            }
        }
        
        private void NavigateToUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            string FormattedURL = "null";

            // add if url contains top level domain (.com etc.) then add https:// if it dosent then do search engine

            if (url.Contains("."))
            {
                // Add http:// prefix if no protocol specified
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    FormattedURL = "https://" + url;
                }

                try
                {
                    if (FormattedURL == "null")
                    {
                        WebViewControl.Source = new Uri(url);
                    }
                    else
                    {
                        WebViewControl.Source = new Uri(FormattedURL);
                    }
                }
                catch (UriFormatException)
                {
                    // If URL is invalid, use a search engine
                    WebViewControl.Source = new Uri($"https://www.google.com/search?q={Uri.EscapeDataString(url)}");
                }
            }
            else
            {
                // If URL is invalid, use a search engine
                WebViewControl.Source = new Uri($"https://www.google.com/search?q={Uri.EscapeDataString(url)}");
            }

            
        }
    }
}
