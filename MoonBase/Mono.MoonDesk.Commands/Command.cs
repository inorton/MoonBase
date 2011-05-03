using System;
using System.Windows;
using System.Windows.Controls;

namespace Mono.MoonDesk.Commands
{
  public class Utils
  {
    static Utils()
    {
      CommandProperty = DependencyProperty.RegisterAttached(
        "Command", typeof(string), typeof(Utils), new PropertyMetadata( null ) );
    }

    public Utils()
    {

    }

    /// <summary>
    /// Finds the FrameworkElement parent of the child.
    /// </summary>
    /// <returns>
    /// The parent.
    /// </returns>
    /// <param name='child'>
    /// Child.
    /// </param>
    public static FrameworkElement FindParent( DependencyObject child )
    {
      var element = child as FrameworkElement;
      if ( element != null ){
        return element.Parent as FrameworkElement;
      } else {
        return null;
      }
    }

    /// <summary>
    /// Finds the data context applicable to the child control.
    /// </summary>
    /// <returns>
    /// The data context.
    /// </returns>
    /// <param name='child'>
    /// Child.
    /// </param>
    public static object FindDataContext ( DependencyObject child )
    {
      object context = null;
      FrameworkElement parent = child as FrameworkElement;
      do {
        if ( parent != null ){
          context = parent.DataContext;
          if ( context != null ) return context;
          parent = FindParent( parent );
        } else {
          return null;
        }
      } while ( true );
    }



    /// <summary>
    /// Disable a control based on a supplied method (of DataContext) name.
    /// </summary>
    public static readonly DependencyProperty CanExecuteProperty = DependencyProperty.RegisterAttached(
      "CanExecute", typeof(bool), typeof(Utils), new PropertyMetadata(
        delegate( DependencyObject sender, DependencyPropertyChangedEventArgs args ){

        }
       ) );

    public static bool GetCanExecute( DependencyObject obj )
    {
      return false;
    }

    public static void SetCanExecute( DependencyObject obj, bool isEnabled )
    {

    }

    /// <summary>
    /// Execute the named method on activation.
    /// </summary>
    public static readonly DependencyProperty CommandProperty;

    public static string GetCommand( DependencyObject obj )
    {
      Console.Out.WriteLine("xx GetCommand {0}", obj.ToString() );
      return String.Empty;
    }

    public static void SetCommand( DependencyObject obj, string command )
    {
      Console.Out.WriteLine("xx SetCommand {0} {1}", obj.ToString(), command );
      if ( obj is Button ){
        (obj as Button).Content = command;
      }
    }
  }
}
