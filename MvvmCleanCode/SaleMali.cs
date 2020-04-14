using MvvmCleanCode.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCleanCode
{
    public class SaleMali 
    {
        public SaleMali()
        {
            ConfigDatabaseConnection();
        }
        public string CurrentSalMali 
        { 
            get { return Settings.Default.DatabaseName; }
            set
            {
                if (!isCurrentSalMali(value))
                {
                    ChangeSetting(value);
                    ConfigDatabaseConnection();
                }
                
            }
        }
        
        private static void ChangeSetting(string value)
        {
            Settings.Default.DatabaseName = value;
            Settings.Default.Save();
            Settings.Default.Reload();
        }
        //public bool isThisYearSalMAli()
        //{
        //    return int.Parse(CurrentSalMali) == PersianDateTime.Now.Year;
        //}
        public bool isCurrentSalMali(string changeSal)
        {
            return changeSal == Settings.Default.DatabaseName;
        }
        private void ConfigDatabaseConnection()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Clear();
            //config.ConnectionStrings.ConnectionStrings.Add(
            //    new ConnectionStringSettings("CString", getConnectionString(databaseName), "System.Data.SqlServerCe.4.0"));
            config.ConnectionStrings.ConnectionStrings.Add(
                new ConnectionStringSettings("CString", getConnectionString(), "System.Data.SqlClient"));
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        private string databaseDefaultPath = System.AppDomain.CurrentDomain.BaseDirectory ;
        private string databaseNameWithExtension = Settings.Default.DatabaseName + ".mdf";
        private string getConnectionString()
        {
            //var path = databaseName + ".sdf";
            //return "Data Source=|DataDirectory|\\" + path;
            return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databaseDefaultPath + databaseNameWithExtension
                + ";Integrated Security=True;Connect Timeout=30";
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(String info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}
    }
}
