using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using Moonlight.Gtk;

namespace Mono.MoonDesk.MoonBase
{
	public class MoonBase
	{
		public static void Init()
		{
			MoonlightRuntime.Init();
		}
		
		public static void PreloadAssemblies( IEnumerable<Assembly> assemblies )
		{
			if ( CanPreloadDesktopAssemblies ){
				var pi = typeof(System.Windows.Deployment).GetProperty( "PreloadDesktopAssemblies", BindingFlags.Static );
				IList<Assembly> alist = pi.GetValue( null, null ) as IList<Assembly>;
				if ( alist != null )
					foreach (var a in assemblies)
						alist.Add( a );
			} else {
				throw NotSupportedException("this version of moonlight can only use appmanifest to load extra assemblies");
			}
			
		}
		
		public static bool CanPreloadDesktopAssemblies { 
			get {
				var pi = typeof(System.Windows.Deployment).GetProperty( "PreloadDesktopAssemblies", BindingFlags.Static );
				return ( pi != null );
			} 
		}
	}
}

