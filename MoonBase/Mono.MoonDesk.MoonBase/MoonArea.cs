using System;
using Moonlight.Gtk;
using System.Windows.Controls;

namespace Mono.MoonDesk
{
  public class MoonArea : MoonlightHost, ISilverlightContainer
  {
    public MoonArea () : base()
    {
      Content = new UserControl();
    }
  }
}

