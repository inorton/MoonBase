using System;
using System.Linq;
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


    public FrameworkElement ToolbarControl {
      get {
        var vm = new ToolbarViewModel();
        var v = ViewMappings.Resolver.LoadXaml ("/Views;component/Views/Toolbar.xaml" ) as FrameworkElement;
        v.DataContext = vm;

        return v;
      }
    }

    public string TestButtonText {
      get { return String.Format("Click Me ({0})", clickCount ); }
    }
    public DelegateCommand TestCommand { get; set; }

    public void RunTestCommand( object param )
    {
      clickCount++;
      NotifyPropertyChanged( "TestButtonText" );
    }

    public bool CanTestCommand( object param )
    {
      return true;
    }

    public string RunningOOB {
      get {
#if MOONLIGHT_DESKTOP
        return System.Windows.Application.Current.IsRunningOutOfBrowser.ToString();
#else
          return "WPF";
#endif
      }
    }
  }
}
