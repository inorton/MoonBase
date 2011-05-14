using System;
using System.Windows;
using System.Windows.Input;

namespace Mono.MoonDesk.Commands
{
  public class DelegateCommand : ICommand {

    public event EventHandler CanExecuteChanged;

    Action<object> executeAction;
    Func<object,bool> canExecuteFunction;
    bool canExecuteState = false;

    public DelegateCommand( Action<object> executeMethod,
      Func<object,bool> checkCanExecute )
    {
      executeAction = executeMethod;
      canExecuteFunction = checkCanExecute;
    }

    #region ICommand members

    public void Execute(object arg )
    {
      executeAction(arg);
    }

    public bool CanExecute(object arg)
    {
      var tmpcan = canExecuteFunction(arg);
      if ( canExecuteState != tmpcan ){
        canExecuteState = tmpcan;
        if ( CanExecuteChanged != null )
          CanExecuteChanged(this, new EventArgs());
      }
      return tmpcan;
    }

    #endregion

    
  }
}
