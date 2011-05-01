using System;

using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using Moonlight.Gtk;
using MoonDesk;

namespace MyApp
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Gtk.Application.Init ();
      MoonlightRuntime.Init();

      var resolver = new ViewResolver();
      var win = new MoonWindow ();

      // Load embedded xaml from resource
      win.Content = resolver.Loader.LoadView<object>( "Views;MoonDesk/Views/Home.xaml" ).View;


      win.Show ();
      Gtk.Application.Run ();
    }
  }
}
