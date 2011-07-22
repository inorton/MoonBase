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
    private bool IsRunning = false;
    private VVM toolbar = null;
    public bool WantStop { get; set; }


    public HomeViewModel()
    {
      TestCommand = new DelegateCommand( ToggleTestCommand, CanTestCommand );
      toolbar = ViewMappings.Resolver.LoadViewViewModel<ToolbarViewModel>("/Views;component/Views/Toolbar.xaml");
      ProgressValue = 0.0;
    }

    public FrameworkElement ToolbarControl {
      get {
          return toolbar.View;
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
        Console.WriteLine("Clicked! {0}",IsRunning);
        if (IsRunning && !WantStop)
        {
            DispatchNotifySetProperty(() => WantStop, true);
        }
        else
        {
            DispatchNotifySetProperty(() => WantStop, false);
            task = new Thread(new ThreadStart(BackgroundTask));
            task.Start();
        }
        DispatchNotifySetProperty(() => ToggleTestButtonText, null);
        Dispatcher.BeginInvoke(new Action(delegate { TestCommand.NotifyCanExecuteChanged(); }));
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
        Dispatcher.BeginInvoke(new Action(delegate { TestCommand.NotifyCanExecuteChanged(); }));
        ProgressValue = 0.0;
        while (!WantStop)
        {
            Console.Error.Write(".");
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
        Dispatcher.BeginInvoke(new Action(delegate { TestCommand.NotifyCanExecuteChanged(); }));
    }


  }
}
