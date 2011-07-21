#if MOONLIGHT_DESKTOP
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

using Mono.MoonDesk;
using Moonlight.Gtk;

namespace Mono.MoonDesk
{

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

        private Point GetCurrentSize()
        {
            int w = 0;
            int h = 0;
            GetSize( out w, out h );

            var p = new Point();
            p.X = w;
            p.Y = h;

            return p;
        }

        public double Width {
            get  {
                return GetCurrentSize().X;
            }
            set {
                var size = GetCurrentSize();
                this.Resize( (int)value, (int) size.Y );
            }
        }

        public double Height {
            get  {
                return GetCurrentSize().Y;
            }
            set {
                var size = GetCurrentSize();
                this.Resize( (int) size.X, (int)value );
            }
        }
    }
}
#endif