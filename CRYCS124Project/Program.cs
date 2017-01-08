using System;
using System.Windows.Forms;

namespace lolcode_interpreter
{
    static class Program
    {
        /// The main entry point for the application.
        
        public static main_form main;
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(main = new main_form());
        }
    }
}
