using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;

#if MOONLIGHT_DESKTOP
using Moonlight.Gtk;
#else

#endif

namespace Mono.MoonDesk
{
#if MOONLIGHT_DESKTOP
    public class MoonArea : MoonlightHost, ISilverlightContainer
    {
        public MoonArea () : base()
        {
            Content = new UserControl ();
        }

        public new FrameworkElement Content {
            get { return (FrameworkElement)System.Windows.Application.Current.RootVisual; }
            set {
                MoonBaseDeployment.InitializeDeployment( null, null );
                System.Windows.Application.Current.RootVisual = value;
            }
        }
    }
#else
    public class MoonArea
    {
        private MoonArea() { }
    }
#endif
}

