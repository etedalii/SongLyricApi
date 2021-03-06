using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SongLyricDataAccess.Data;
using SongLyricDataAccess.Data.Repository;
using SongLyricDataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo4WebApi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
