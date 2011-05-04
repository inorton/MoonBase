using System;
using System.ComponentModel;
using System.Windows;

namespace Mono.MoonDesk
{
  public abstract class ViewModelBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModelBase ()
    {
    }

    public FrameworkElement View { get; set; }

    protected void OnPropertyChanged( string propertyName )
    {
      PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
    }
  }
}
