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

      MoonWindow win = new MoonWindow ();

      var x = new UserControl();
      win.Content = x; // for some reason i need to force the mlhost to load somthing first
      win.Content = resolver.Loader.LoadView<object>( "Views;MoonDesk/Views/Home.xaml" ).View;


      win.Show ();
      Gtk.Application.Run ();
    }
  }
}
