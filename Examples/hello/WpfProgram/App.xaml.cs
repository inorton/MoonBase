using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;

using Mono.MoonDesk;
using MoonBase.Examples;

namespace WpfProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void  OnStartup(StartupEventArgs e)
        {
 	        base.OnStartup(e);
            var win = new Mono.MoonDesk.AWindow();

            var home = ViewMappings.Resolver.LoadViewViewModel<HomeViewModel>("/Views;component/Views/Home.xaml");
            win.Content = home.View;
            home.View.Visibility = Visibility.Visible;
            win.Show();
        }
    }
}
