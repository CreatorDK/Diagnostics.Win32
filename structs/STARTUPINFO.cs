using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace CreatorDK.Diagnostics.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public class STARTUPINFO
    {
        public int cb;
        public IntPtr lpReserved = IntPtr.Zero;
        public IntPtr lpDesktop = IntPtr.Zero;
        public IntPtr lpTitle = IntPtr.Zero;
        public int dwX = 0;
        public int dwY = 0;
        public int dwXSize = 0;
        public int dwYSize = 0;
        public int dwXCountChars = 0;
        public int dwYCountChars = 0;
        public int dwFillAttribute = 0;
        public int dwFlags = 0;
        public short wShowWindow = 0;
        public short cbReserved2 = 0;
        public IntPtr lpReserved2 = IntPtr.Zero;
        public SafeFileHandle hStdInput = new SafeFileHandle(IntPtr.Zero, false);
        public SafeFileHandle hStdOutput = new SafeFileHandle(IntPtr.Zero, false);
        public SafeFileHandle hStdError = new SafeFileHandle(IntPtr.Zero, false);

        public STARTUPINFO()
        {
            cb = Marshal.SizeOf(this);
        }

        public void Dispose()
        {
            // close the handles created for child process
            if (hStdInput != null && !hStdInput.IsInvalid)
            {
                hStdInput.Close();
                hStdInput = null;
            }

            if (hStdOutput != null && !hStdOutput.IsInvalid)
            {
                hStdOutput.Close();
                hStdOutput = null;
            }

            if (hStdError != null && !hStdError.IsInvalid)
            {
                hStdError.Close();
                hStdError = null;
            }
        }
    }
}
