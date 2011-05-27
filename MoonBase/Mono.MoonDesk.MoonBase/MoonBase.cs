using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using Moonlight.Gtk;

namespace Mono.MoonDesk
{
	public class MoonBase
	{
		public static void Init()
		{
			MoonlightRuntime.Init();
		}

    public static void Init( IEnumerable<Assembly> preload )
    {
      Init();
      PreloadAssemblies( preload );
    }
		
		static void PreloadAssemblies( IEnumerable<Assembly> assemblies )
		{
			if ( CanPreloadDesktopAssemblies )
      {
      	var fi = typeof(System.Windows.Deployment).GetField( "PreloadDesktopAssemblies" );
        if ( fi != null )
        {
				  var alist = fi.GetValue( null ) as List<Assembly>;
				  if ( alist != null )
          {
					  alist.AddRange( assemblies );
            return;
          }
        }
			} else {
				throw new NotSupportedException("this version of moonlight can only use appmanifest to load extra assemblies");
			}
			
		}
		
		public static bool CanPreloadDesktopAssemblies { 
			get {
				var fi = typeof(System.Windows.Deployment).GetField( "PreloadDesktopAssemblies" );
				return ( fi != null );
			} 
		}
	}
}

