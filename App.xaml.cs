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
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ControlCenter
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();

            // WinUIEx
            // https://dotmorten.github.io/WinUIEx

            // Window Extension Methods:
            // m_window.Minimize();
            // m_window.Maximize();
            // m_window.Restore();
            // m_window.Hide();
            // m_window.CenterOnScreen();
            // m_window.SetWindowSize(1024, 768);
            // m_window.MoveAndResize(100, 100, 1024, 768);
            // m_window.SetIsAlwaysOnTop(true);
            // m_window.BringToFront();

            // Window Manager:
            // var manager = WinUIEx.WindowManager.Get(m_window);
            // manager.PersistenceId = "MainWindowPersistanceId";
            // manager.MinWidth = 640;
            // manager.MinHeight = 480;
            // manager.Backdrop = new WinUIEx.MicaSystemBackdrop();

            var manager = WinUIEx.WindowManager.Get(m_window);

            m_window.CenterOnScreen();
            m_window.Maximize();
            manager.MinWidth = 900;
            manager.MinHeight = 480;
        }

        private Window? m_window;
    }
}
