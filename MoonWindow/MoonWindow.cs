using System;
using Moonlight.Gtk;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MoonDesk
{
  public class MoonWindow : Gtk.Window
  {
    private MoonlightHost _host = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="MoonDesk.MoonWindow"/> class.
    /// </summary>
    public MoonWindow (): base (Gtk.WindowType.Toplevel)
    {
      _host = new MoonlightHost ();
      this.WidthRequest = 320;
      this.HeightRequest = 200;
      this.Add (_host);
      this.ShowAll ();

      // hack else XamlLoader in moonlight 2.x wont find any managed control classes   
      _host.Content = new UserControl();

    }

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    /// <value>
    /// The content.
    /// </value>
    public FrameworkElement Content {
      get {
        return _host.Content;
      }
      set {
        _host.Content = value;
      }
    }
  }
}