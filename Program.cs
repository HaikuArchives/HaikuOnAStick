using System;
using System.Windows.Forms;

/* 
 * Copyright 2008 - 2009, Haiku, Inc. All Rights Reserved. 
 * Distributed under the terms of the MIT License. 
 * 
 * Authors: 
 *              Fredrik Modéen, (Firstname@lastname.se)
 */ 

namespace Haiku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new HaikuOnAStick());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
