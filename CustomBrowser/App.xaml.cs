using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;
using CefSharp.SchemeHandler;

namespace CustomBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void Init()
        {
            Cef.EnableHighDPISupport();
            CefSharpSettings.ShutdownOnExit = false;
            var settings = new CefSettings()
            {

                // Increase the log severity so CEF outputs detailed information, useful for debugging
                LogSeverity = LogSeverity.Verbose,
                // By default CEF uses an in memory cache, to save cached data e.g. passwords you need to specify a cache path
                // NOTE: The executing user must have sufficient privileges to write to this folder.
                CachePath = "cache"
            };

            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = "localfolder",
                DomainName = "cefsharp",
                SchemeHandlerFactory = new FolderSchemeHandlerFactory(rootFolder: GetPath(@"Library\html"),
                            hostName: "cefsharp", //Optional param no hostname/domain checking if null
                            defaultPage: "home.html") //Optional param will default to index.html
            });
            Cef.Initialize(settings);
        }

        public static string GetPath(string path = "")
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string rootPath = Uri.UnescapeDataString(uri.Path);
            return Path.Combine(Path.GetDirectoryName(rootPath), path);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Init();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Cef.Shutdown();
        }
    }
}
