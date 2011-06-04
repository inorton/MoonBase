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
      Mono.MoonDesk.MoonBase.Init();

      var anames = Application.Current.GetType().Assembly.GetReferencedAssemblies();
      foreach ( var aname in anames ){
        Console.WriteLine("load {0}", aname );
        var a = Assembly.Load( aname );
        Mono.MoonDesk.MoonBase.Assemblies.Add( a );
      }
      var asm = System.Reflection.Assembly.LoadFile("/usr/local/lib/mono/moonlight/System.Windows.Controls.dll");
      Mono.MoonDesk.MoonBase.Assemblies.Add( asm );



      var win = new MoonWindow ();


      // Load embedded xaml from resource
      ViewMappings.MoonlightHost = win.Host;
      var home = ViewMappings.Resolver.GetHomeView();
      win.Content = home.View as FrameworkElement;



      win.Show ();
      win.Resize( 640,350 );
      Gtk.Application.Run ();

      
    }
  }
}
