using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace CardReader
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct WFSVersion
        {
            public ushort wVersion;      // Version number
            public ushort wLowVersion;   // Low version number
            public ushort wHighVersion;  // High version number
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDescription; // Description
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szSystemStatus; // System status

            public string SzDescription { get => szDescription; set => szDescription = value; }
        }

        // Event classes
        private const uint SERVICE_EVENTS = 0x00000001;
        private const uint USER_EVENTS = 0x00000002;
        private const uint SYSTEM_EVENTS = 0x00000004;
        private const uint EXECUTE_EVENTS = 0x00000008;

        //
        private const uint WFS_IDC_TRACK1 = 0x00000001;
        private const uint WFS_IDC_TRACK2 = 0x00000002;
        private const uint WFS_IDC_TRACK3 = 0x00000004;

        // Importing the necessary functions from the DLLs
        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSStartUp(uint dwVersionsRequired, out WFSVersion lpWFSVersion);


        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSOpen(
            string lpszLogicalName,
            uint hApp,
            string lpszAppID,
            uint dwTraceLevel,
            uint dwTimeOut,
            uint dwSrvcVersionsRequired,
            ref WFSVersion lpSrvcVersion,
            ref WFSVersion lpSPIVersion,
            ref IntPtr lphService
        );

        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSRegister(IntPtr hService, uint dwEventClass, IntPtr hWndReg);



        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int WFSCreateAppHandle(out IntPtr lphApp);



        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSLock(IntPtr hService, uint dwTimeOut, out IntPtr lppResult);

        [StructLayout(LayoutKind.Sequential)]
        public struct WFSRESULT
        {
            public IntPtr hService;       // Service handle
            public uint RequestID;        // Request ID
            public uint hResult;          // Result code
            public IntPtr lpBuffer;       // Pointer to the result buffer
            public uint uTimeout;         // Timeout duration
        }

        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSFreeResult(IntPtr lpResult);


        private IntPtr hService;


        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSGetInfo(
            IntPtr hService,
            uint dwCategory,
            IntPtr lpQueryDetails,
            uint dwTimeOut,
            out IntPtr lppResult
        );

        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WFSIsBlocking();

        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSAsyncExecute(
            IntPtr hService,
            uint dwCommand,
            uint lpCmdData,
            uint dwTimeOut,
            IntPtr hWnd,
            ref IntPtr lpRequestID
        );




        public Form1()
        {
            try
            {

                WFSVersion versionInfo = new WFSVersion(); // Initialize the structure


                uint versionRequired = 0x00030003;

                int hResult = WFSStartUp(versionRequired, out versionInfo);
                if (hResult != 0)
                {

                    return; // Exit if startup fails
                }
            }
            catch { }

            InitializeComponent();
        }

        private void WFSStartUp_Click(object sender, EventArgs e)
        {
            try
            {

                WFSVersion versionInfo = new WFSVersion(); // Initialize the structure
                uint versionRequired = 0x00030003;

                int hResult = WFSStartUp(versionRequired, out versionInfo);
                if (hResult != 0)
                {
                    WFSStartUpResult.Text = $"WFSStartUp failed with error code: {hResult}";
                    return; // Exit if startup fails
                }
                WFSStartUpResult.Text = $"WFSStartUp succeeded, version: {versionInfo.wVersion}, {versionInfo.SzDescription}";

            }
            catch (DllNotFoundException ex)
            {
                WFSStartUpResult.Text = $"DLL not found: {ex.Message}";
            }
            catch (AccessViolationException ex)
            {
                WFSStartUpResult.Text = $"Access violation: {ex.Message}";
            }
            catch (Exception ex)
            {
                WFSStartUpResult.Text = $"Unexpected error: {ex.Message}";
            }
        }

        private void WFSOpen_Click(object sender, EventArgs e)
        {

            try
            {
                IntPtr appHandle = IntPtr.Zero;
                int result = WFSCreateAppHandle(out appHandle);

                if (result != 0)
                {
                    WFSOpenResult.Text = $"WFSCreateAppHandle failed with error: {result}";
                    return;
                }

                string logicalName = "IDC30"; // Replace with your device's logical name
                uint hApp = (uint)appHandle.ToInt32(); // Correct handle conversion
                string appID = ""; // Application identifier
                uint traceLevel = 0x0000000A; // Trace level (adjust as needed)
                uint timeout = 18000; // Timeout in milliseconds
                uint versionsRequired = 0x00030003; // Service version required

                WFSVersion srvcVersion = new WFSVersion();
                WFSVersion spiVersion = new WFSVersion();

                hService = IntPtr.Zero; // Initialize service handle

                // Call WFSOpen instead of Native_WFSOpen
                int hResult = WFSOpen(
                    logicalName,
                    hApp,
                    appID,
                    traceLevel,
                    timeout,
                    versionsRequired,
                    ref srvcVersion,
                    ref spiVersion,
                    ref hService
                );

                if (hResult != 0)
                {
                    WFSOpenResult.Text = $"WFSOpen failed with error code: {hResult}";
                    return;
                }

                WFSOpenResult.Text = $"WFSOpen succeeded. Service Handle: {hService}";
            }
            catch (EntryPointNotFoundException ex)
            {
                WFSOpenResult.Text = $"Entry point not found: {ex.Message}";
            }
            catch (Exception ex)
            {
                WFSOpenResult.Text = $"Unexpected error: {ex.Message}";
            }
        }

        private void WFSRegister_Click(object sender, EventArgs e)
        {
            if (hService == IntPtr.Zero)
            {
                WFSRegisterResult.Text = "Invalid service handle. Ensure WFSOpen succeeded.";
                return;
            }

            uint eventClasses = SERVICE_EVENTS| SYSTEM_EVENTS | USER_EVENTS | EXECUTE_EVENTS;
            IntPtr hWndReg = this.Handle;

            int hResult = WFSRegister(hService, eventClasses, hWndReg);

            if (hResult != 0)
            {
                WFSRegisterResult.Text = $"WFSRegister failed with error code: {hResult}";
            }
            else
            {
                WFSRegisterResult.Text = "WFSRegister succeeded. Event monitoring enabled.";
            }
        }

        private void WFSLockBtn_Click(object sender, EventArgs e)
        {
            if (hService == IntPtr.Zero)
            {
                WFSLockResult.Text = "Service handle is invalid. Ensure WFSOpen was successful.";
                return;
            }

            try
            {
                IntPtr pResult;
                uint timeout = 30000; // Timeout in milliseconds (adjust as needed)

                int hResult = WFSLock(hService, timeout, out pResult);

                if (hResult == 0) // WFS_SUCCESS
                {
                    WFSRESULT result = Marshal.PtrToStructure<WFSRESULT>(pResult);
                    WFSLockResult.Text = $"WFSLock succeeded. Request ID: {result.RequestID}";

                    // Free the result memory
                    WFSFreeResult(pResult);
                }
                else
                {
                    WFSLockResult.Text = $"WFSLock failed with error code: {hResult}";
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                WFSLockResult.Text = $"Entry point not found: {ex.Message}";
            }
            catch (Exception ex)
            {
                WFSLockResult.Text = $"Unexpected error: {ex.Message}";
            }
        }

        private void WFSGetInfoBtn_Click(object sender, EventArgs e)
        {
            if (hService == IntPtr.Zero)
            {
                WFSGetInfoResult.Text = "Invalid service handle.";
                return;
            }

            try
            {
                
                uint dwCategory = 0xC9; 

                IntPtr lpQueryDetails = IntPtr.Zero; // No extra query details needed
                uint timeout = 30000; // Timeout in milliseconds
                IntPtr pResult;

                int hResult = WFSGetInfo(hService, dwCategory, lpQueryDetails, timeout, out pResult);

                if (hResult == 0) // WFS_SUCCESS
                {
                    WFSRESULT result = Marshal.PtrToStructure<WFSRESULT>(pResult);
                    WFSGetInfoResult.Text = $"WFSGetInfo succeeded. Request ID: {result.RequestID}";

                    // Free the result memory
                    WFSFreeResult(pResult);
                }
                else
                {
                    WFSGetInfoResult.Text = $"WFSGetInfo failed with error code: {hResult}";
                }
            }
            catch (Exception ex)
            {
                WFSGetInfoResult.Text = $"Unexpected error: {ex.Message}";
            }
        }

        private void WFSIsBlockingBtn_Click(object sender, EventArgs e)
        {
            if (hService == IntPtr.Zero)
            {
                WFSIsBlockingResult.Text = "Invalid service handle.";
                return;
            }

            // Check if a blocking operation is in progress
            if (WFSIsBlocking())
            {
                WFSIsBlockingResult.Text = "Another blocking operation is in progress.";
                return;
            }

            try
            {
                uint dwCategory = 0xC9; // WFS_INF_IDC_STATUS (IDC status information)
                IntPtr lpQueryDetails = IntPtr.Zero; // No additional query details required for status
                uint timeout = 30000; // Timeout in milliseconds (30 seconds)
                IntPtr pResult;

                // Call WFSGetInfo to get the IDC status
                int hResult = WFSGetInfo(hService, dwCategory, lpQueryDetails, timeout, out pResult);

                if (hResult == 0) // WFS_SUCCESS
                {
                    WFSRESULT result = Marshal.PtrToStructure<WFSRESULT>(pResult);
                    WFSIsBlockingResult.Text = $"WFSGetInfo succeeded. Request ID: {result.RequestID}";

                    // Free the result memory
                    WFSFreeResult(pResult);
                }
                else
                {
                    WFSIsBlockingResult.Text = $"WFSGetInfo failed with error code: {hResult}";
                }
            }
            catch (Exception ex)
            {
                WFSIsBlockingResult.Text = $"Unexpected error: {ex.Message}";
            }
        }

        private void WFSAsyncExecuteBtn_Click(object sender, EventArgs e)
        {
            if (hService == IntPtr.Zero)
            {
                WFSAsyncExecuteResult.Text = "Invalid service handle.";
                return;
            }

            // Check if a blocking operation is in progress
            if (WFSIsBlocking())
            {
                WFSAsyncExecuteResult.Text = "Another blocking operation is in progress.";
                return;
            }

            try
            {

                IntPtr lpRequestID = IntPtr.Zero;
                
                // Set lpCmdData as the combination of the tracks
                uint lpCmdData = 7; // 7 = 00000001 | 00000010 | 00000100

                uint dwCommand = 0xCF;  // Example command, use the correct one for your device
                uint dwTimeOut = 30000; // Timeout in milliseconds (30 seconds)

                IntPtr hWnd = this.Handle; // This refers to the window handle, which you need to pass

                // Call the WFSAsyncExecute function
                int hResult = WFSAsyncExecute(hService, dwCommand, lpCmdData, dwTimeOut, hWnd, ref lpRequestID);

                if (hResult == 0) // WFS_SUCCESS
                {
                    uint requestID = (uint)lpRequestID.ToInt32(); 
                    WFSAsyncExecuteResult.Text = $"WFSAsyncExecute succeeded. Request ID: {requestID}";
                }
                else
                {
                    WFSAsyncExecuteResult.Text = $"WFSAsyncExecute failed with error: {hResult}";
                }
            }
            catch (Exception ex)
            {
                WFSAsyncExecuteResult.Text = $"Error during WFSAsyncExecute: {ex.Message}";
            }
        }
    }
}