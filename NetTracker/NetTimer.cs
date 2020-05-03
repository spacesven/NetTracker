using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NetTracker
{
    public partial class NetTimer : ServiceBase
    {
        public NetTimer()
        {
            InitializeComponent();
        }


        private static System.Timers.Timer aTimer;
        
        protected override void OnStart(string[] args)
        {
            AutoLog = false;
            WriteEntry("NetTracker","Service Started", EventLogEntryType.Information);
            ConnectionEstablished = true;

            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
            
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            //WriteEntry("NetTracker", "Timer Runns",EventLogEntryType.SuccessAudit);
            if (CheckForInternetConnection() == false & ConnectionEstablished == true)
            {
                WriteEntry("NetTracker", "Connection Offline", EventLogEntryType.Error);
                ConnectionEstablished = false;
            }
            else if (CheckForInternetConnection() == true & ConnectionEstablished == false)
            {
                WriteEntry("NetTracker", "Connection Online", EventLogEntryType.SuccessAudit);
                ConnectionEstablished = true;
            }
        }



        protected override void OnStop()
        {
            WriteEntry("NetTracker", "Service Ready for uninstall", EventLogEntryType.Information);
        }

        public bool ConnectionEstablished;

  
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static void WriteEntry(string source, string message, System.Diagnostics.EventLogEntryType type)
        {
            System.Diagnostics.EventLog.WriteEntry(source,message,type);
        }
    }
}
