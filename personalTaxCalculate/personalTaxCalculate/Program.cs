﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personalTaxCalculate
{
    static class Program
    {
        static TaxManager sTaxMng = new TaxManager();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain frm = new frmMain();
            frm.TaxMng = sTaxMng;
            frm.Show();
            Application.Run();
        }
    }
}
