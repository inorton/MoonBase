using System;
using System.Windows;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

#if MOONLIGHT_DESKTOP
using Moonlight.Gtk;
#endif

namespace Mono.MoonDesk
{
    public class MoonBase
    {
		public static List<Assembly> Assemblies = new List<Assembly>();
        public static void Init ()
        {
#if MOONLIGHT_DESKTOP
            MoonlightRuntime.Init ();
#endif
        }	

#if MOONLIGHT_DESKTOP		
        internal static void CallPrivateStaticVoidExternMethod( Type t, string methodname, params object[] args )
        {
            var mi = t.GetMethod( methodname, BindingFlags.NonPublic|BindingFlags.DeclaredOnly );
            if ( mi == null ) throw new MoonBaseException("cant find static method {0} on type {1}", methodname, t);
            mi.Invoke( null, args );
        }

        internal static object CallPrivateInstanceMethod(object instance, string methodName, params object[] args )
        {
            var mi = instance.GetType().GetMethod( methodName, BindingFlags.NonPublic|BindingFlags.Instance );
            if ( mi == null ) throw new MoonBaseException("cant find method {0} on object {1}", methodName, instance );

            return mi.Invoke( instance, args );
        }

        internal static object GetPrivateInstanceProperty(object instance, string propertyName )
        {
            var pi = instance.GetType().GetProperty( propertyName, BindingFlags.NonPublic|BindingFlags.Instance );
            if ( pi == null ) throw new MoonBaseException("cant find property {0} on object {1}", propertyName, instance );

            return pi.GetValue( instance, null );
        }

        internal static void SetPrivateInstanceProperty(object instance, string propertyName, object value )
        {
            var pi = instance.GetType().GetProperty( propertyName, BindingFlags.NonPublic|BindingFlags.Instance );
            if ( pi == null ) throw new MoonBaseException("cant find property {0} on object {1}", propertyName, instance );

            pi.SetValue( instance, value, null );
        }
		
		internal static object GetPrivateInstanceField(object instance, string fieldName )
        {
            var fi = instance.GetType().GetField( fieldName, BindingFlags.NonPublic|BindingFlags.Instance );
            if ( fi == null ) throw new MoonBaseException("cant find field {0} on object {1}", fieldName, instance );

            return fi.GetValue( instance );
        }
		
		internal static void SetPrivateInstanceField(object instance, string fieldName, object value )
        {
            var fi = instance.GetType().GetField( fieldName, BindingFlags.NonPublic|BindingFlags.Instance );
            if ( fi == null ) throw new MoonBaseException("cant find field {0} on object {1}", fieldName, instance );

            fi.SetValue( instance, value );
        }
#endif 
		
    }
}

