using System;
using System.Reflection;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Markup;
using System.Windows.Controls;

using Moonlight.Gtk;

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
        if ( Host == null ) {
          view = XamlReader.Load( xamlstr ) as FrameworkElement;
        } else {
          view = Host.CreateElementFromString( xamlstr, true ) as DependencyObject;
        }

        if ( (view != null ) && ( dataContext != null ) ){
          var fe = view as FrameworkElement;
          if ( fe != null ){
            fe.DataContext = dataContext;
          }
        }
      }

      return view;
    }

    /// <summary>
    /// Loads the view.
    /// </summary>
    /// <returns>
    /// The view.
    /// </returns>
    /// <param name='componentPath'>
    /// Component path.
    /// </param>
    /// <typeparam name='VMType'>
    /// The 1st type parameter.
    /// </typeparam>
    public XamlView<VMType> LoadView<VMType>( string componentPath )
      where VMType : class, new ()
    {
      if ( componentPath.Contains(";") ){
        var slist = componentPath.Split(new char[] { ';' });
        if ( slist.Length == 2 ){
          var asmname = slist[0];
          var path = slist[1];
          var ppath = path.Replace('/','.');

          return LoadView<VMType>( asmname, ppath, new VMType() );
        }
      }
      throw new InvalidDataException("resource path invalid");
    }

    /// <summary>
    /// Loads the view.
    /// </summary>
    /// <returns>
    /// The view.
    /// </returns>
    /// <param name='assembly'>
    /// Assembly.
    /// </param>
    /// <param name='viewfile'>
    /// Viewfile.
    /// </param>
    /// <param name='vm'>
    /// Vm.
    /// </param>
    /// <typeparam name='VMType'>
    /// The 1st type parameter.
    /// </typeparam>
    public XamlView<VMType> LoadView<VMType>(string assembly, string viewfile, VMType vm)
      where VMType : class
    {
      var view = LoadViewXaml( assembly, viewfile, vm );

      var xv = new XamlView<VMType>();
      xv.View = view;
      xv.ViewModel = vm;

      var vmb = xv.ViewModel as MoonDesk.ViewModelBase;
      if ( vmb != null )
        vmb.View = view;


      return xv;
    }
  }
}
