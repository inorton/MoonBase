using System;
using MoonDesk;
using System.Windows;

namespace MoonBase.Examples
{
  public class HomeViewModel : ViewModelBase
  {
    
    public HomeViewModel ()
    {
    }

    private XamlView<ToolbarViewModel> _toolbar;
    public FrameworkElement ToolbarControl {
      get {
        _toolbar = Resolver.GetHomeToolbar();
        return _toolbar.View;
      }
    }

  }
}
