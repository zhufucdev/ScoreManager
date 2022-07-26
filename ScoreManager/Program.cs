using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            if (args.Length > 0)
            {
                string target;
                if (args.Contains("--open-last"))
                {
                    target = Settings.Default.RecentProjects[0];
                }
                else
                {
                    target = args[0];
                }
                form1.OpenFile(target);
            }
            Application.Run(form1);
        }
    }
}
