using System;
using Moonlight.Gtk;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
// using Gtk;

public partial class MoonWindow: Gtk.Window
{
  private MoonlightHost _host = null;
  public MoonWindow (): base (Gtk.WindowType.Toplevel)
  {
    Build ();
    _host = new MoonlightHost();

    this.Add( _host );
    this.ShowAll();
  }

  public FrameworkElement Content {
    get {
      return _host.Content;
    }
    set {
      _host.Content = value;
    }
  }

  protected void OnDeleteEvent (object sender, Gtk.DeleteEventArgs a)
  {
    Gtk.Application.Quit ();
    a.RetVal = true;
  }

}
