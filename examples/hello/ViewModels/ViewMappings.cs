using System;
using System.Collections.Generic;
using Mono.MoonDesk;

namespace MoonBase.Examples
{
  public class ViewMappings : ViewResolver
  {
    public static Moonlight.Gtk.MoonlightHost MoonlightHost = null;
    public static ViewMappings Resolver = new ViewMappings( MoonlightHost );

    public ViewMappings ( Moonlight.Gtk.MoonlightHost host ) : base( host )
    {
    }

    public XamlView<HomeViewModel> GetHomeView()
    {
      return Loader.LoadView<HomeViewModel>( "Views;MoonDesk/Views/Home.xaml" );
    }

    public XamlView<ToolbarViewModel> GetHomeToolbar()
    {
      return Loader.LoadView<ToolbarViewModel>( "Views;MoonDesk/Views/Toolbar.xaml" );
    }

  }
}
