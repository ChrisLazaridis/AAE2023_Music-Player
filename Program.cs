﻿using System;
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
            Application.Run(new musicPlayerForm());
        }
    }
}
