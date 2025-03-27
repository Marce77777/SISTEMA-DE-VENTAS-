using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Microsoft.Data.SqlClient;//
//using System.Data;
//using System.Data.SqlClient; // Para SQL Server
using CapaPresentacion;


namespace sistema_ventas
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
         //    Application.Run(frmArticulo.GetInstancia());
            //   Application.Run(new FrmMarca());
            //Application.Run(new frmUsuario());
            //Application.Run(new frmPrincipal());
            Application.Run(new frmLogin());
        }
    }
}