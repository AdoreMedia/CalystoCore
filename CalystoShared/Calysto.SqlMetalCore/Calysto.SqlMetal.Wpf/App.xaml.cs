using Calysto.SqlMetal.Model;
using Calysto.SqlMetal.Wpf.Views.MainWindow;
using Calysto.SqlMetal.Wpf.Views.MainWindow.Models;
using Calysto.SqlMetal.Wpf.Views.OrmGenerator.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Calysto.SqlMetal.Wpf
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public static ServiceProvider ServiceProvider => ((App)Application.Current)._serviceProvider;

        private ServiceProvider _serviceProvider;

        private void SetDefaultCulture()
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)
                )
            );
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceCollection services = new ServiceCollection();
            string settingsFile = e.Args.FirstOrDefault();
            this.ConfigureServices(services, settingsFile);
            _serviceProvider = services.BuildServiceProvider();

            this.SetDefaultCulture();

			// show main window
			_serviceProvider.GetService<MainWindowView>().Show();
		}

        private void ConfigureServices(ServiceCollection services, string settingsFile)
        {
            services.AddSingleton(DatabaseSettings.Load(settingsFile));
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<OrmGeneratorViewModel>();
            services.AddSingleton<MainWindowView>();
        }

        public App()
        {
        }
    }
}
