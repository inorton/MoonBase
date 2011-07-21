#if !MOONLIGHT_DESKTOP
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

using Mono.MoonDesk;

namespace Mono.MoonDesk
{
    public class AWindow : Window, IWindow {
        public MoonArea Host { get; private set; }

        public void Resize( int w, int h )
        {
            this.Width = (double)w;
            this.Height = (double)h;
        }
    }
}

#endif
