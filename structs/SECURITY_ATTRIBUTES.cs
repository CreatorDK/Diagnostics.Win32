using System;

namespace CreatorDK.Diagnostics.Win32
{
    public struct SECURITY_ATTRIBUTES
    {
        public uint nLength;

        public IntPtr lpSecurityDescriptor;

        public int bInheritHandle;
    }
}
