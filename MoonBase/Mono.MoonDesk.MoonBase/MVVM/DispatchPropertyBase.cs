using System;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using System.ComponentModel;
using System.Runtime.InteropServices;

using System.Linq;
using System.Linq.Expressions;

namespace Mono.MoonDesk
{
    public interface IDispatcherObject
    {
        Dispatcher Dispatcher { get; set; }
    }
                         
    public class DispatchPropertyBase : NotifyPropertyBase, IDispatcherObject
    {
        public Dispatcher Dispatcher { get; set; }

        public void DispatchNotifySetProperty<T>(Expression<Func<T>> exp, T value)
        {
            if (Dispatcher != null)
            {
                Dispatcher.BeginInvoke((Action)delegate
                {
                    NotifySetProperty(exp, value);
                });
            }
            else
            { // just set the property if no dispatcher is availible
                var prop = GetProperty(exp);
                prop.SetValue(this, value, null);
            }
        }
    }
}
