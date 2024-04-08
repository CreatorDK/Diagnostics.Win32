using System;
using System.Runtime.InteropServices;

namespace CreatorDK.Diagnostics.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public class PROCESS_INFORMATION
    {
        // The handles in PROCESS_INFORMATION are initialized in unmanaged functions. 
        // We can't use SafeHandle here because Interop doesn't support [out] SafeHandles in structures/classes yet. 
        public IntPtr hProcess = IntPtr.Zero;
        public IntPtr hThread = IntPtr.Zero;
        public int dwProcessId = 0;
        public int dwThreadId = 0;

        // Note this class makes no attempt to free the handles 
        // Use InitialSetHandle to copy to handles into SafeHandles
    }
}
