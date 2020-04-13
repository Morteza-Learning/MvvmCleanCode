using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace MvvmCleanCode
{
    public static class DatabaseChanger
    {
        public static void ChangeDatabaseNameTo(string databaseName)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();
            //config.ConnectionStrings.ConnectionStrings.Add(
            //    new ConnectionStringSettings("CString", getConnectionString(databaseName), "System.Data.SqlServerCe.4.0"));
            config.ConnectionStrings.ConnectionStrings.Add(
                new ConnectionStringSettings("CString", getConnectionString(databaseName), "System.Data.SqlClient"));
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        private static string getConnectionString(string databaseName)
        {
            //var path = databaseName + ".sdf";
            //return "Data Source=|DataDirectory|\\" + path;
            var path = databaseName + ".mdf";
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.AppDomain.CurrentDomain.BaseDirectory + path
                + ";Integrated Security=True;Connect Timeout=30";
        }

        public static void BackUpDatabase(string databaseName)
        {
            string copypath = System.Environment.CurrentDirectory + "\\" + databaseName + ".mdf";
            string despath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists(copypath))
            {
                File.Copy(copypath, despath + Path.GetFileName(copypath));
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}
