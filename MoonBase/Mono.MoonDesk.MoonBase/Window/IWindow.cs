using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Automation.Peers;

#if MOONLIGHT_DESKTOP
using MoonlightHost = Moonlight.Gtk.MoonlightHost;
#else
using MoonlightHost = object;
#endif

using Mono.MoonDesk;

namespace System.Windows.Controls
{
    public interface IWindow
    {
        //
        // Summary:
        //     Gets or sets a window's icon. This is a dependency property.
        //
        // Returns:
        //     An System.Windows.Media.ImageSource object that represents the icon.
        ImageSource Icon { get; set; }

        //
        // Summary:
        //     Gets a value that indicates whether the window is active. This is a dependency
        //     property.
        //
        // Returns:
        //     true if the window is active; otherwise, false. The default is false.
        bool IsActive { get; }

        double Width { get; set; }
        double Height { get; set; }

        MoonArea Host { get; }

        void Resize( int w, int h );

        // Summary:
        //     Gets or sets a value that indicates whether the window has a task bar button.
        //     This is a dependency property.
        //
        // Returns:
        //     true if the window has a task bar button; otherwise, false. Does not apply
        //     when the window is hosted in a browser.
        bool ShowInTaskbar { get; set; }

#if !MOONLIGHT_DESKTOP
        //
        // Summary:
        //     Gets or sets the resize mode. This is a dependency property.
        //
        // Returns:
        //     A System.Windows.ResizeMode value specifying the resize mode.
        ResizeMode ResizeMode { get; set; }

        //
        // Summary:
        //     Gets or sets a value that indicates whether a window will automatically size
        //     itself to fit the size of its content. This is a dependency property.
        //
        // Returns:
        //     A System.Windows.SizeToContent value. The default is System.Windows.SizeToContent.Manual.
        SizeToContent SizeToContent { get; set; }
#endif
        //
        // Summary:
        //     Gets or sets a window's title. This is a dependency property.
        //
        // Returns:
        //     A System.String that contains the window's title.
        string Title { get; set; }

        //
        // Summary:
        //     Gets or sets a value that indicates whether a window is restored, minimized,
        //     or maximized. This is a dependency property.
        //
        // Returns:
        //     A System.Windows.WindowState that determines whether a window is restored,
        //     minimized, or maximized. The default is System.Windows.WindowState.Normal
        //     (restored).
        WindowState WindowState { get; set; }

        //
        // Summary:
        //     Gets or sets a window's border style. This is a dependency property.
        //
        // Returns:
        //     A System.Windows.WindowStyle that specifies a window's border style. The
        //     default is System.Windows.WindowStyle.SingleBorderWindow.
        WindowStyle WindowStyle { get; set; }

        // Summary:
        //     Occurs when a window becomes the foreground window.
        event EventHandler Activated;

        //
        // Summary:
        //     Occurs when the window as about to close.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.UIElement.Visibility is set, or System.Windows.Window.Show(),
        //     System.Windows.Window.ShowDialog(), or System.Windows.Window.Hide() is called
        //     while a window is closing.
        event EventHandler Closed;

        //
        // Summary:
        //     Occurs when a window becomes a background window.
        event EventHandler Deactivated;

        //
        // Summary:
        //     Occurs when the window's System.Windows.Window.WindowState property changes.
        event EventHandler StateChanged;

        // Summary:
        //     Attempts to bring the window to the foreground and activates it.
        //
        // Returns:
        //     true if the System.Windows.Window was successfully activated; otherwise,
        //     false.
        bool Activate();

        //
        // Summary:
        //     Manually closes a System.Windows.Window.
        void Close();

        //
        // Summary:
        //     Makes a window invisible.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.Hide() is called on a window that is closing (System.Windows.Window.Closing)
        //     or has been closed (System.Windows.Window.Closed).
        void Hide();

        //
        // Summary:
        //     Opens a window and returns without waiting for the newly opened window to
        //     close.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.Show() is called on a window that is closing (System.Windows.Window.Closing)
        //     or has been closed (System.Windows.Window.Closed).
        void Show();

        //
        // Summary:
        //     Opens a window and returns only when the newly opened window is closed.
        //
        // Returns:
        //     A System.Nullable<T> value of type System.Boolean that signifies how a window
        //     was closed by the user.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Windows.Window.ShowDialog() is called on a System.Windows.Window that
        //     is visible -or- System.Windows.Window.ShowDialog() is called on a visible
        //     System.Windows.Window that was opened by calling System.Windows.Window.ShowDialog().
        //
        //   System.InvalidOperationException:
        //     System.Windows.Window.ShowDialog() is called on a window that is closing
        //     (System.Windows.Window.Closing) or has been closed (System.Windows.Window.Closed).
        bool? ShowDialog();


#region ContentControl members
        // Summary:
        //     Gets or sets the content of a System.Windows.Controls.ContentControl. This
        //     is a dependency property.
        //
        // Returns:
        //     An object that contains the control's content. The default value is null.
        object Content { get; set; }

#if !MOONLIGHT_DESKTOP
        //
        // Summary:
        //     Gets or sets a composite string that specifies how to format the System.Windows.Controls.ContentControl.Content
        //     property if it is displayed as a string.
        //
        // Returns:
        //     A composite string that specifies how to format the System.Windows.Controls.ContentControl.Content
        //     property if it is displayed as a string.
        string ContentStringFormat { get; set; }

        //
        // Summary:
        //     Gets or sets the data template used to display the content of the System.Windows.Controls.ContentControl.
        //     This is a dependency property.
        //
        // Returns:
        //     A data template. The default value is null.
        DataTemplate ContentTemplate { get; set; }

        //
        // Summary:
        //     Gets or sets a template selector that enables an application writer to provide
        //     custom template-selection logic. This is a dependency property.
        //
        // Returns:
        //     A data template selector. The default value is null.
        DataTemplateSelector ContentTemplateSelector { get; set; }
#endif
        //
        // Summary:
        //     Gets a value that indicates whether the System.Windows.Controls.ContentControl
        //     contains content. This is a dependency property.
        //
        // Returns:
        //     true if the System.Windows.Controls.ContentControl has content; otherwise
        //     false. The default value is false.
        bool HasContent { get; }
#endregion

    }
}
