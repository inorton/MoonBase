using System;
using System.Windows;
using System.Windows.Controls;
using Mono.MoonDesk.Commands;
using Mono.MoonDesk;

namespace MoonBase.Examples
{
  public class HomeViewModel : ViewModelBase
  {
    int clickCount = 0;

    public HomeViewModel()
    {
      TestCommand = new DelegateCommand( RunTestCommand, CanTestCommand );

    }

    private XamlView<ToolbarViewModel> _toolbar;
    public FrameworkElement ToolbarControl {
      get {
        _toolbar = ViewMappings.Resolver.GetHomeToolbar();
        if ( _toolbar != null )
          return _toolbar.View as FrameworkElement;

        return null;
      }
    }

    public string TestButtonText {
      get { return String.Format("Click Me ({0})", clickCount ); }
    }
    public DelegateCommand TestCommand { get; set; }

    public void RunTestCommand( object param )
    {
      clickCount++;
      OnPropertyChanged( "TestButtonText" );
    }

    public bool CanTestCommand( object param )
    {
      return true;
    }
  }
}
