using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Reflection;
using System.Collections.Generic;

namespace Mono.MoonDesk
{
    public static class MoonBaseDeployment
    {
        public static bool InitializeDeployment (string culture, string uiCulture)
        {
            var dep = Deployment.Current;
            // TerminateAndSetCulture (culture, uiCulture);
            MoonBase.CallPrivateInstanceMethod (dep, "TerminateAndSetCulture", culture, uiCulture);

            // NativeMethods.deployment_set_initialization (native, true);
            var native = (IntPtr) MoonBase.GetPrivateInstanceProperty (dep, "native");
            var swa = dep.GetType ().Assembly;
            var nm = swa.GetType ("Mono.NativeMethods");

            if (nm == null)
                throw new MoonBaseException ("cant get type {0}", "Mono.NativeMethods");

            deployment_set_initialization( native, true );

            try {
                var pi = dep.GetType().GetProperty("EntryPointType");
                pi.SetValue( dep, "System.Windows.Application", null );

                pi = dep.GetType().GetProperty("EntryPointAssembly");
                pi.SetValue( dep, typeof(System.Windows.Application).Assembly.GetName().Name, null );

                MoonBase.SetPrivateInstanceProperty (dep, "EntryAssembly", typeof(Application).Assembly);
                return LoadAssemblies ();
            } finally {
                deployment_set_initialization( native, false );
            }
        }

        [DllImport ("moon", EntryPoint="_moonlight_cbinding_deployment_set_initialization", CharSet=CharSet.Auto)]
        // void _moonlight_cbinding_deployment_set_initialization (Deployment *instance, bool init);
        extern static void deployment_set_initialization (IntPtr instance, [MarshalAs (UnmanagedType.U1)] bool init);


        static bool LoadAssemblies ()
        {
            var dep = Deployment.Current;
            var asms = new List<Assembly> ();
            asms.AddRange (MoonBase.Assemblies);
            asms.Add (typeof(Application).Assembly);

            MoonBase.SetPrivateInstanceField (dep, "assemblies", asms);

            return (bool)MoonBase.CallPrivateInstanceMethod (dep, "CreateApplication");
        }
    }
}

