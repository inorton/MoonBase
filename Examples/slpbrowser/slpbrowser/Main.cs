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

      var resolver = new ViewResolver( win.Host );

      var slist = resolver.Loader.LoadView<ServiceListViewModel>( "Views;Views/Views/ServiceList.xaml");

      win.Content = slist.View;

      win.Show ();
      Gtk.Application.Run ();


    }
  }
}
