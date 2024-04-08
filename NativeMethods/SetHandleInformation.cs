using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace CreatorDK.Diagnostics.Win32.NativeMethods
{
    public partial class Handle
    {
        [DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Process)]
        internal static extern bool SetHandleInformation(
            [In]
            IntPtr handle,
            [In]
            uint mask,
            [In]
            uint flags
            );
    }
}
