using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
using CefSharp.Wpf;
using CustomBrowser.Library;
using MahApps.Metro.Controls;
using Reports.Library;

namespace CustomBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ChromiumWebBrowser browser;
        public MainWindow()
        {
            InitializeComponent();

            //var url = "https://cefsharp.com/";
            var url = "localfolder://cefsharp/";
            browser = new ChromiumWebBrowser()
            {
                Address = url,
                BrowserSettings =
                {
                    DefaultEncoding = "UTF-8",
                    WebGl = CefState.Disabled
                }
            };

            browser.RegisterJsObject("bound", new BoundObject(), BindingOptions.DefaultBinder);
            browser.RegisterAsyncJsObject("boundAsync", new AsyncBoundObject(), BindingOptions.DefaultBinder);
            uxContent.Content = browser;
        }

        private void ShowReport_Click(object sender, RoutedEventArgs e)
        {
            ReportManager.Run();
        }

        private void ShowDevTools_Click(object sender, RoutedEventArgs e)
        {
            browser.ShowDevTools();
        }
    }
}
