using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CreatorDK.Diagnostics.Win32.NativeMethods
{
    public partial class Process
    {
        [DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Process)]
        internal static extern bool CreateProcess(
            [In, Optional, MarshalAs(UnmanagedType.LPTStr)]
            string lpApplicationName,                          // LPCTSTR
            [In, Out, Optional]
            StringBuilder lpCommandLine,                        // LPTSTR - note: CreateProcess might insert a null somewhere in this string 
            [In, Optional]
            SECURITY_ATTRIBUTES lpProcessAttributes,           // LPSECURITY_ATTRIBUTES
            [In, Optional]
            SECURITY_ATTRIBUTES lpThreadAttributes,            // LPSECURITY_ATTRIBUTES
            [In]
            bool bInheritHandles,                               // BOOL 
            [In]
            uint dwCreationFlags,                               // DWORD
            [In, Optional, MarshalAs(UnmanagedType.LPStr)]
            StringBuilder lpEnvironment,                        // LPVOID 
            [In, Optional, MarshalAs(UnmanagedType.LPTStr)]
            string lpCurrentDirectory,                          // LPCTSTR
            [In]
            STARTUPINFO lpStartupInfo,                          // LPSTARTUPINFO
            [In, Out]
            PROCESS_INFORMATION lpProcessInformation        // LPPROCESS_INFORMATION 
        );
    }
}
