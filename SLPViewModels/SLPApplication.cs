using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace slpmoon
{
  public class SLPApplication
  {
    ViewLoader loader = null;

    public SLPApplication ( )
    {
      loader = new ViewLoader( );
      var views = Assembly.Load("SLPViews");
      foreach ( var rname in views.GetManifestResourceNames() )
        Console.WriteLine(rname);
    }

    public XamlView<ViewModelBase> MainToolbar {
      get {
        return loader.LoadView<ViewModelBase>("SLPViews","SLPViews.Views.Toolbar.xaml");
      }
    }

    public XamlView<HomeViewModel> Home {
      get {
        return loader.LoadView<HomeViewModel>("SLPViews","SLPViews.Views.Home.xaml");
      }
    }

  }
}
