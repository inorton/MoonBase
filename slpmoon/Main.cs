using System;

using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using Moonlight.Gtk;

namespace slpmoon
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      Gtk.Application.Init ();
      MoonlightRuntime.Init();

      SLPApplication app = new SLPApplication();

      MoonWindow win = new MoonWindow ();

      var x = new UserControl();
      win.Content = x; // for some reason i need to force the mlhost to load somthing first
      win.Content = app.Home.View;


      win.Show ();
      Gtk.Application.Run ();
    }
  }
}
