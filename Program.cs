using SMT.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMT
{
    static class Program
    {

        public static PVSServiceReference.USERSEntity _user;
        public static State lineState = State.OK;
        public static string FuncNG = "";
        public static List<UsapService.BCLBFLMEntity> _upn_cache = new List<UsapService.BCLBFLMEntity>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool result;
            var mutex = new System.Threading.Mutex(true, "Support Material", out result);
            if (!result)
            {
                MessageBox.Show("Program is already running.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var fileRun = VersionHelper.CheckVersion();
          
            Application.Run(new frmMain());
        }
    }
}
