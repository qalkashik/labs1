    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using labs1;
    using global::labs1;

    namespace labs1
    {
        public static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ReportForm());
            }
        }
    }

