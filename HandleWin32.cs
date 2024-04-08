using System;

namespace CreatorDK.Diagnostics.Win32
{
    public partial class HandleWin32
    {
        public static bool SetHandleInformation(IntPtr handle, uint mask, uint flags)
        {
            return NativeMethods.Handle.SetHandleInformation(handle, mask, flags);
        }

        public static bool CloseHandle(IntPtr handle)
        {
            return NativeMethods.Handle.CloseHandle(handle);
        }
    }
}
