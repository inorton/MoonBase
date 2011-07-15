using System;

using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using Moonlight.Gtk;

using Mono.MoonDesk;

using ViewModels;

namespace slpbrowser
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Gtk.Application.Init ();
      MoonlightRuntime.Init();

      var win = new MoonWindow ();

      var resolver = new ViewLoader( win.Host );

      var slist = resolver.LoadViewViewModel<ServiceListViewModel>( "Views;Views/Views/ServiceList.xaml");

      win.Content = slist.View as System.Windows.FrameworkElement;

      win.Show ();
      win.Resize( 650, 350 );
      Gtk.Application.Run ();


    }
  }
}
