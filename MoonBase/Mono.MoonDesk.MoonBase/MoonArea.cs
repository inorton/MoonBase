using System;
using System.Collections.Generic;
using Moonlight.Gtk;
using System.Windows;
using System.Windows.Controls;

using System.Reflection;

namespace Mono.MoonDesk
{
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
}

