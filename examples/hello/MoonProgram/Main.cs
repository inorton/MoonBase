using System;

using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using Moonlight.Gtk;
using MoonBase.Examples;
using Mono.MoonDesk;

namespace MyApp
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Gtk.Application.Init ();
      MoonlightRuntime.Init();


      var win = new MoonWindow ();

      // Load embedded xaml from resource
      ViewMappings.MoonlightHost = win.Host;
      var home = ViewMappings.Resolver.GetHomeView();
      win.Content = home.View;


      win.Show ();
      Gtk.Application.Run ();

      
    }
  }
}
