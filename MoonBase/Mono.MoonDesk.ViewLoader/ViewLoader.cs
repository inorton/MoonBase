using System;
using System.Reflection;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Markup;
using System.Windows.Controls;

#if MOONLIGHT_DESKTOP
using Moonlight.Gtk;
#endif

namespace Mono.MoonDesk
{
  public class XamlViewBase {
    /// <summary>
    /// Gets or sets the view.
    /// </summary>
    /// <value>
    /// The view.
    /// </value>
    public DependencyObject View { get; set; }
  }

  public class XamlView<VMType> : XamlViewBase
    where VMType : class {
    /// <summary>
    /// Gets or sets the view model.
    /// </summary>
    /// <value>
    /// The view model.
    /// </value>
    public VMType ViewModel { get; set; }
  }

#if !MOONLIGHT_DESKTOP
  // keeps the windows build working, just dont use this on windows
  public class MoonlightHost : Object {
      private MoonlightHost() {}
  }
#endif

  public class ViewLoader
  {
    public MoonlightHost Host { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MoonDesk.ViewLoader"/> class.
    /// </summary>
    public ViewLoader( MoonlightHost mhost ) {
      Host = mhost;
    }

    /// <summary>
    /// Loads the view xaml.
    /// </summary>
    /// <returns>
    /// The view xaml.
    /// </returns>
    /// <param name='assemblyName'>
    /// Assembly name.
    /// </param>
    /// <param name='manifestName'>
    /// Manifest name.
    /// </param>
    /// <param name='dataContext'>
    /// Data context.
    /// </param>
    public DependencyObject LoadViewXaml( string assemblyName, string manifestName, object dataContext )
    {
      DependencyObject view = null;

      var asm = Assembly.Load( assemblyName );
      var stream = asm.GetManifestResourceStream( manifestName );

      if ( stream == null )
        throw new InvalidDataException( String.Format("missing resource {1} in {0}", assemblyName, manifestName ));


      var xamlstr = String.Empty;

      using ( var sr = new StreamReader(stream) ){
        xamlstr = sr.ReadToEnd();
      }

      if ( xamlstr != null ){

#if MOONLIGHT_DESKTOP
        if ( Host == null ) {
          view = XamlReader.Load( xamlstr ) as FrameworkElement;
        } else {
          view = Host.CreateElementFromString( xamlstr, true ) as DependencyObject;
        }
#else
        view = Application.LoadComponent(new Uri(String.Format("/{0};component/{1}", assemblyName, manifestName), UriKind.Relative)) as DependencyObject;
#endif

        if ( (view != null ) && ( dataContext != null ) ){
          var fe = view as FrameworkElement;
          if ( fe != null ){
            fe.DataContext = dataContext;
          }
        }
      }

      return view;
    }
  }
}
