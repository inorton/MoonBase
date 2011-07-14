using System;
using System.Windows;
using System.Windows.Input;

namespace Mono.MoonDesk.Commands
{
  /// <summary>
  /// A simple, bindable ICommand implementation.
  /// </summary>
  public class DelegateCommand : ICommand {

    /// <summary>
    /// Notify that the 'CanExecute' property may have changed.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    Action<object> executeAction;
    Func<object,bool> canExecuteFunction;
    bool canExecuteState = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="Mono.MoonDesk.Commands.DelegateCommand"/> class.
    /// </summary>
    /// <param name='executeMethod'>
    /// Execute method.
    /// </param>
    /// <param name='checkCanExecute'>
    /// Check can execute.
    /// </param>
    public DelegateCommand( Action<object> executeMethod,
      Func<object,bool> checkCanExecute )
    {
      executeAction = executeMethod;
      canExecuteFunction = checkCanExecute;
    }

    #region ICommand members

    /// <summary>
    /// Executes the delegate.
    /// </summary>
    /// <param name="arg"></param>
    public void Execute(object arg )
    {
      executeAction(arg);
    }

    /// <summary>
    /// Checks if the delegate can be executed.
    /// </summary>
    /// <param name="arg"></param>
    /// <returns>True if the command can be executed.</returns>
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
