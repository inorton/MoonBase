using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MoonDesk
{
  public class ViewResolver {

    public ViewLoader Loader { get; private set; }

    public ViewResolver ( )
    {
      Loader = new ViewLoader( null );
    }

    public ViewResolver ( Moonlight.Gtk.MoonlightHost host )
    {
      Loader = new ViewLoader( host );
    }

  }
}
