using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#if MOONLIGHT_DESKTOP
using Moonlight.Gtk;
#endif

namespace Mono.MoonDesk
{
#if MOONLIGHT_DESKTOP
  public class MoonWindow : Gtk.Window, ISilverlightContainer
  {
    private MoonArea _host = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="MoonDesk.MoonWindow"/> class.
    /// </summary>
    public MoonWindow (): base (Gtk.WindowType.Toplevel)
    {
      _host = new MoonArea();
      this.Add (_host);
      this.ShowAll ();

    }

    public MoonArea Host {
      get { return _host; }
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
#else
    public class MoonWindow
    {
        private MoonWindow() { }
    }
#endif
}