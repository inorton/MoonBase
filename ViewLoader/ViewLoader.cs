using System;
using System.Reflection;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Markup;
using System.Windows.Controls;

namespace slpmoon
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
