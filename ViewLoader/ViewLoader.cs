using System;
using System.Reflection;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Markup;
using System.Windows.Controls;

namespace MoonDesk
{
  public class XamlView<VMType> {
    public FrameworkElement View { get; set; }
    public VMType ViewModel { get; set; }
  }

  public class ViewLoader
  {
    public ViewLoader ()
    {

    }

    public FrameworkElement LoadView( string assemblyName, string filename, object ViewModel )
    {
      FrameworkElement view = null;

      Console.WriteLine("want to load assembly {0}", assemblyName );

      var asm = Assembly.Load( assemblyName );
      var stream = asm.GetManifestResourceStream( filename );

      var xamlstr = String.Empty;

      using ( var sr = new StreamReader(stream) ){
        xamlstr = sr.ReadToEnd();
      }

      if ( xamlstr != null ){
        view = XamlReader.Load( xamlstr ) as FrameworkElement;

        if ( view != null ){
          view.DataContext = ViewModel;
        }
      }

      return view;
    }

    public XamlView<VMType> LoadView<VMType>( string componentPath )
      where VMType : new ()
    {
      if ( componentPath.Contains(";") ){
        var slist = componentPath.Split(new char[] { ';' });
        if ( slist.Length == 2 ){
          var asmname = slist[0];
          var path = slist[1];
          var ppath = path.Replace('/','.');

          return LoadView<VMType>( asmname, ppath );
        }
      }
      return null; // must be relative path
    }

    public XamlView<VMType> LoadView<VMType>(string assembly, string viewfile)
      where VMType : new()
    {
      var vm = new VMType();
      var view = LoadView( assembly, viewfile, vm );

      var xv = new XamlView<VMType>();
      xv.View = view;
      xv.ViewModel = vm;

      return xv;
    }
  }
}
