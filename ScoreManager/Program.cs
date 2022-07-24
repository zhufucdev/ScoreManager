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
                if (args.Contains("--open-last"))
                {
                    form1.Recent_Click(null, null);
                }
                else
                {
                    form1.OpenProject(Statics.Project.Open(args[0]));
                }
            }
            Application.Run(form1);
        }
    }
}
