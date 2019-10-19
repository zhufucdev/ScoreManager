using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ScoreManager
{
    public static class ResourceController
    {
        public static ComponentResourceManager ApplySource(Form form)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.Default.Language);
            ComponentResourceManager res = new ComponentResourceManager(form.GetType());
            System.Reflection.FieldInfo[] fieldInfo = form.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            form.SuspendLayout();
            foreach(System.Reflection.FieldInfo info in fieldInfo)
            {
                object control = info.GetValue(form);
                if (control != null)
                    res.ApplyResources(control, info.Name);
            }
            form.ResumeLayout();
            res.ApplyResources(form, "this");
            return res;
        }
    }
}
