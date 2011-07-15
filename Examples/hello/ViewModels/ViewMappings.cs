using System;
using System.Collections.Generic;
using Mono.MoonDesk;

namespace MoonBase.Examples
{
  public class ViewMappings
  {
    public static Moonlight.Gtk.MoonlightHost MoonlightHost = null;
    public static ViewLoader Resolver = new ViewLoader( MoonlightHost );
  }
}
