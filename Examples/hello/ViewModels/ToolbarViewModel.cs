using System;
using System.Windows;
using Mono.MoonDesk;
using Mono.MoonDesk.Commands;

namespace MoonBase.Examples
{
  public class ToolbarViewModel : ViewModelBase
  {
    
    public ToolbarViewModel ()
    {
        WpfClickedCommand = new DelegateCommand(new Action<object>( delegate {
            wasWpfClicked = true;
            WpfClickedCommand.NotifyCanExecuteChanged();
        }), CanExecuteWpf);

        Ml4ClickedCommand = new DelegateCommand(new Action<object>(delegate
        {
            wasMl4Clicked = true;
            Ml4ClickedCommand.NotifyCanExecuteChanged();
        }), CanExecuteMl4);
    }

    public DelegateCommand WpfClickedCommand { get; set; }
    private bool wasWpfClicked = false;
    public bool CanExecuteWpf( object arg )
    {
        return !wasWpfClicked;
    }

    public DelegateCommand Ml4ClickedCommand { get; set; }
    private bool wasMl4Clicked = false;
    public bool CanExecuteMl4(object arg)
    {
        return !wasMl4Clicked;
    }
  }
}

