using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

using Mono.MoonDesk;

#if MOONLIGHT_DESKTOP
using Moonlight.Gtk;

#endif

namespace Mono.MoonDesk
{
  
#if MOONLIGHT_DESKTOP
    public class AWindow : MoonWindow , IWindow {

        public event EventHandler Activated;

        public event EventHandler Closed;

        public event EventHandler Deactivated;

        public new event EventHandler StateChanged;

        public new ImageSource Icon {
            get {
                throw new NotImplementedException ();
            }
            set {
                throw new NotImplementedException ();
            }
        }

        public bool ShowInTaskbar {
            get {
                return !SkipTaskbarHint;
            }
            set {
                SkipTaskbarHint = value;
            }
        }

        public WindowState WindowState {
            get {
                throw new NotImplementedException ();
            }
            set {
                throw new NotImplementedException ();
            }
        }

        public WindowStyle WindowStyle {
            get {
                return WindowStyle.SingleBorderWindow;
            }
            set {

            }
        }

        public void Close ()
        {
            this.Hide();
            this.Destroy();
        }

        public new bool Activate ()
        {
            this.Show();
            this.UrgencyHint = true;

            if ( Activated != null )
                Activated( this, new EventArgs () );

            return true;
        }

        public bool? ShowDialog ()
        {
            return true;
        }

        public new object Content {
            get {
                return base.Content;
            }
            set {
                if ( value is FrameworkElement )
                    base.Content = value as FrameworkElement;
            }
        }

        public bool HasContent {
            get {
                return ( base.Content != null );
            }
        }

    }
#else
    public class AWindow : Window, IWindow {

    }
#endif
  
}
