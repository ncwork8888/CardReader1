using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

        private const int WFS_ERR_CANCELED = -1;
        private const int WFS_ERR_CONNECTION_LOST = -2;
        private const int WFS_ERR_INTERNAL_ERROR = -15;

        // Importing the necessary functions from the DLLs
        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int WFSStartUp(uint dwVersionsRequired, out WFSVersion lpWFSVersion);


        [DllImport(@"C:\Windows\SysWOW64\msxfs.dll", EntryPoint = "WFSOpen", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int Native_WFSOpen(
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
        public static extern int XFSRegister(int hService, IntPtr pRegister);

        
        private IntPtr hService;

        public Form1()
        {
            InitializeComponent();
        }

        private void WFSStartUp_Click(object sender, EventArgs e)
        {
            try
            {
                
                WFSVersion versionInfo = new WFSVersion(); // Initialize the structure
                uint versionRequired = 3; 

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
            WFSOpenResult.Text = "Ads";
            try
            {
                string logicalName = "IDC30"; // Replace with your device logical name
                uint hApp = 0; // Application handle (can be 0 if not needed)
                string appID = ""; // Application identifier
                uint traceLevel = 0; // Trace level (1 for example)
                uint timeout = 18000; // Timeout in milliseconds
                uint versionsRequired = 0x00030003; // Service version required

                WFSVersion srvcVersion = new WFSVersion();
                WFSVersion spiVersion = new WFSVersion();

                hService = IntPtr.Zero; // Initialize the service handle

                int hResult = Native_WFSOpen(
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
                    string v = hResult switch
                    {
                        WFS_ERR_CANCELED => "The request was canceled by WFSCancelBlockingCall.",
                        WFS_ERR_CONNECTION_LOST => "The connection to the service is lost.",
                        WFS_ERR_INTERNAL_ERROR => "An internal inconsistency or unexpected error occurred.",
                        _ => $"Unknown error occurred. HRESULT: {hResult}"
                    };
                    string errorMessage = v;

                    WFSOpenResult.Text = $"WFSOpen failed: {errorMessage}";
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
            WFSRegisterResult.Text = "Ads";

        }
    }
}
