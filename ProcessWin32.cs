using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace CreatorDK.Diagnostics.Win32
{
    public partial class ProcessWin32
    {
        string _applicationName;
        string _commandLine;
        SECURITY_ATTRIBUTES? _processSecurityAttributes;
        SECURITY_ATTRIBUTES? _threadSecurityAttributes;
        bool _inheritHandles = false;
        uint _creationFlags = 0;
        string _environment;
        string _currentDirectory;
        readonly STARTUPINFO _startupInfo = new STARTUPINFO();
        PROCESS_INFORMATION _processInformation = new PROCESS_INFORMATION();

        int _processId = 0;
        int _threadId = 0;

        SafeHandle _processHandle;
        IntPtr _threadHandle;

        public string ApplicationName
        {
            get => _applicationName;
            set => _applicationName = value;
        }

        public string CommandLine
        {
            get => _commandLine;
            set => _commandLine = value;
        }

        public SECURITY_ATTRIBUTES? ProcessSecurityAttributes
        {
            get => _processSecurityAttributes;
            set => _processSecurityAttributes = value;
        }

        public SECURITY_ATTRIBUTES? ThreadSecurityAttributes
        {
            get => _threadSecurityAttributes;
            set => _threadSecurityAttributes = value;
        }

        public bool InheritHandles
        {
            get => _inheritHandles;
            set => _inheritHandles = value;
        }

        public uint CreationFlags
        {
            get => _creationFlags;
            set => _creationFlags = value;
        }

        public string Environment
        {
            get => _environment;
            set => _environment = value;
        }

        public string CurrentDirectory
        {
            get => _currentDirectory;
            set => _currentDirectory = value;
        }

        public STARTUPINFO StartupInfo
        {
            get => _startupInfo;
        } 

        public int Id
        {
            get => _processId;
        }

        public int ThreadId
        {
            get => _threadId;
        }

        public SafeHandle ProcessSafeHandle
        {
            get => _processHandle;
        }

        public IntPtr? ThreadDangerousHandle
        {
            get => _threadHandle;
        }

        public ProcessWin32() { }

        public ProcessWin32(STARTUPINFO startupInfo)
        {
            _startupInfo = startupInfo;
        }

        public ProcessWin32(string applicationName, string commandLine = null)
        {
            _applicationName = applicationName;
            _commandLine = commandLine;
        }

        public bool Start ()
        {
#pragma warning disable CS8604 //Marshalling dont support nullable types
#pragma warning disable CS8600
//#pragma warning disable CS8629

            SECURITY_ATTRIBUTES processSecurityAttributes = _processSecurityAttributes == null ? new SECURITY_ATTRIBUTES() : (SECURITY_ATTRIBUTES)_processSecurityAttributes;
            SECURITY_ATTRIBUTES threadSecurityAttributes = _threadSecurityAttributes == null ? new SECURITY_ATTRIBUTES() : (SECURITY_ATTRIBUTES)_threadSecurityAttributes;

            StringBuilder commandLine = null;
            if (_commandLine != null)
                commandLine = new StringBuilder(_commandLine);

            StringBuilder environment = null;
            if (_environment != null)
                environment = new StringBuilder(_environment);

            PROCESS_INFORMATION processInformation = new PROCESS_INFORMATION();

            bool result = NativeMethods.Process.CreateProcess(
                _applicationName,
                commandLine,
                processSecurityAttributes,
                threadSecurityAttributes,
                _inheritHandles,
                _creationFlags,
                environment,
                _currentDirectory,
                _startupInfo,
                processInformation
                );

#pragma warning restore CS8604
#pragma warning restore CS6800
//#pragma warning restore CS8629

            _processInformation = processInformation;

            if (_processInformation != null)
            {
                _processId = _processInformation.dwProcessId;
                _threadId = _processInformation.dwThreadId;

                _processHandle = new SafeProcessHandle(_processInformation.hProcess, true);
                _threadHandle = _processInformation.hThread;
            }

            return result;
        }

        public Process GetProcess()
        {
            return Process.GetProcessById(_processId);
        }
    }
}
