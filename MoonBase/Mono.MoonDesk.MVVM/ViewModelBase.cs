using System;
using System.Windows;

namespace Mono.MoonDesk
{
    public abstract class ViewModelBase : DispatchPropertyBase
    {
        public DependencyObject View { get; set; }
    }
}
