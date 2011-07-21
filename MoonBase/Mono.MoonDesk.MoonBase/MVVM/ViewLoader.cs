using System;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using System.Windows;
using System.Windows.Resources;
using System.Windows.Markup;
using System.Windows.Controls;

#if MOONLIGHT_DESKTOP
using Moonlight.Gtk;
#endif

namespace Mono.MoonDesk
{
    public class XamlViewBase
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public DependencyObject View { get; set; }
    }

    public class XamlView<VMType> : XamlViewBase
    where VMType : class
    {
        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public VMType ViewModel { get; set; }
    }

#if !MOONLIGHT_DESKTOP
    // keeps the windows build working, just dont use this on windows
    public class MoonlightHost : Object
    {
        private MoonlightHost ()
        {
        }
    }

#endif

    public class ViewLoader
    {
        public MoonlightHost Host { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoonDesk.ViewLoader"/> class.
        /// </summary>
        public ViewLoader (MoonlightHost mhost)
        {
            Host = mhost;
        }

        public DependencyObject LoadXaml (string resource)
        {
            DependencyObject view = null;

#if MOONLIGHT_DESKTOP

        // for moonlight-desktop+moonbase we embed xaml directly as streams
        // perhaps one day we will embed baml

        var packuri = Regex.Split( resource, ";" );
        var assemblyName = packuri[0].TrimStart('/');
        var manifestName = Regex.Replace( packuri[1], "^component/", "" );


        var asm = Assembly.Load( assemblyName );
        Console.WriteLine("want  {0}",manifestName);
        foreach (var a in asm.GetManifestResourceNames())
          Console.WriteLine("found {0}",a);

        var stream = asm.GetManifestResourceStream( manifestName );

        if ( stream == null ){ // no resource of that name, try changing any "/" to a "."
            var mname = Regex.Replace( manifestName, "/", "." );
            stream = asm.GetManifestResourceStream( mname );
        }

        if ( stream == null ){
            throw new InvalidDataException( String.Format("unable to load xaml at {0}", resource ));
        }

        var xamlstr = String.Empty;

        using ( var sr = new StreamReader(stream) ){
          xamlstr = sr.ReadToEnd();
        }

        if ( Host == null ) {
          view = XamlReader.Load( xamlstr ) as FrameworkElement;
        } else {
          view = Host.CreateElementFromString( xamlstr, true ) as DependencyObject;
        }

#else
            view = Application.LoadComponent (new Uri (resource, UriKind.Relative)) as DependencyObject;
#endif

            return view;
        }

        public VVM LoadViewViewModel<VM> (string xamlResource)
            where VM : ViewModelBase, new()
        {
            VVM ret = new VVM ();
            ret.ViewModel = new VM ();
            ret.View = LoadXaml (xamlResource) as FrameworkElement;
            if (ret.View != null) {
                ret.View.DataContext = ret.ViewModel;

                if (ret.ViewModel is IDispatcherObject) {
                    ((IDispatcherObject)ret.ViewModel).Dispatcher = ret.View.Dispatcher;
                }
            }

            return ret;
        }
    }
}
