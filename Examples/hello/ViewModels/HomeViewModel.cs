using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using Mono.MoonDesk.Commands;
using Mono.MoonDesk;

namespace MoonBase.Examples
{
  public class HomeViewModel : ViewModelBase
  {
    bool IsRunning = false;
    public bool WantStop { get; set; }

    public HomeViewModel()
    {
      TestCommand = new DelegateCommand( ToggleTestCommand, CanTestCommand );
      ProgressValue = 0.0;
    }

    public FrameworkElement ToolbarControl {
      get {
        var vm = new ToolbarViewModel();
        var v = ViewMappings.Resolver.LoadXaml ("/Views;component/Views/Toolbar.xaml" ) as FrameworkElement;
        v.DataContext = vm;

        return v;
      }
    }

    public string ToggleTestButtonText
    {
        get { 
            if (WantStop) return "Stopping";
            if (IsRunning) return "Stop";
            return "Start";
        }
        set { }
    }

    public DelegateCommand TestCommand { get; set; }

    private Thread task;
    public void ToggleTestCommand( object param )
    {
        if (IsRunning && !WantStop)
        {
            WantStop = true;
        }
        else
        {
            WantStop = false;
            task = new Thread(new ThreadStart(BackgroundTask));
            task.Start();
        }
        DispatchNotifySetProperty(() => ToggleTestButtonText, null);
    }

    public bool CanTestCommand( object param )
    {
        if (WantStop) return false;
        return true;
    }

    public double ProgressValue { get; set; }
    public string Message { get; set; }

    private void BackgroundTask()
    {
        IsRunning = true;
        ProgressValue = 0.0;
        while (!WantStop)
        {
            Thread.Sleep(500);
            if (ProgressValue < 100) {
                DispatchNotifySetProperty(() => ProgressValue, ProgressValue + 2);
                DispatchNotifySetProperty(() => Message, String.Format("{0}...", ProgressValue));
            } else { 
                DispatchNotifySetProperty(() => Message, "Done");
            }

        }

        DispatchNotifySetProperty(() => WantStop, true);
        Thread.Sleep(2500);
        DispatchNotifySetProperty(() => WantStop, false);
        DispatchNotifySetProperty(() => ProgressValue, 0);

        IsRunning = false;
        DispatchNotifySetProperty(() => ToggleTestButtonText, null);
    }


  }
}
