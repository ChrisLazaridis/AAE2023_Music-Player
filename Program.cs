using System;
using System.Windows.Forms;

namespace AAE2023_Music_Player
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = new selectUserForm();
            mainForm.FormClosed += new FormClosedEventHandler(MainFormClosed);
            mainForm.Show();
            Application.Run();
        }

        static void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= MainFormClosed;
            if (Application.OpenForms.Count == 0)
                Application.ExitThread();
            else
                Application.OpenForms[0].FormClosed += MainFormClosed;
        }

    }
}
