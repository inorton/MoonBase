using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Reflection;
using System.ComponentModel;

namespace Mono.MoonDesk
{
    public class NotifyPropertyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Foo { get; set; }

        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        public void NotifySetProperty<T> ( Expression<Func<T>> exp, T value )
        {
            if ( exp != null )
            {
                var member = exp.Body as MemberExpression;
                if (member != null)
                {
                    var prop = GetProperty(exp);
                    if ( prop != null ){
                        prop.SetValue(this, value, null);
                        NotifyPropertyChanged(prop.Name);
                    }
                }
            }
        }
        
        public PropertyInfo GetProperty<T>(Expression<Func<T>> exp)
        {
            if (exp != null)
            {
                var member = exp.Body as MemberExpression;
                if (member != null)
                {
                    var prop = member.Member as PropertyInfo;
                    if (prop != null)
                    {
                        return prop;
                    }
                    throw new InvalidOperationException("expression must be on a property");
                }
            }

            throw new ArgumentNullException("expected expression");
        }
        
    }
}
