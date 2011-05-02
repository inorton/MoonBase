using System;
using System.Collections.Generic;
using MoonDesk;

namespace MoonBase.Examples
{
  public class ViewMappings : ViewResolver
  {
    public static ViewMappings Resolver = new ViewMappings();

    public ViewMappings () : base()
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
