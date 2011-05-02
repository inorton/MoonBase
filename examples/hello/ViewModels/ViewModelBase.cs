using System;
using System.Windows;
using MoonDesk;

namespace MoonBase.Examples
{
  public class ViewModelBase
  {
    public ViewModelBase ()
    {
      Resolver = ViewMappings.Resolver;
    }
    public ViewMappings Resolver { get; set; }

    public FrameworkElement View { get; set; }

  }
}
