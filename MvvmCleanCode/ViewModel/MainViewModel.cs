using Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Configuration;
using System.IO;
using System.Windows;
using System;

namespace MvvmCleanCode.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IService service;
        SaleMali saleMali;
        public MainViewModel(IService _service)
        {
            try
            {
                saleMali = new SaleMali();
                if (saleMali.CurrentSalMali == "temp")
                {
                    BackUpView v = new BackUpView();
                    v.ShowDialog();
                    saleMali.ChangeSalMali("1400");
                    System.Windows.Forms.Application.Restart();
                    System.Windows.Application.Current.Shutdown();
                }
                var c = new ConnectionDatabase();
                c.ConfigDatabaseConnection(saleMali.CurrentSalMali);
                service = _service;
                //این فقط برای اینه که دیتابیس جدید ساخته بشه . در برنامه اصلی هر رفت و امدی به دیتابیس باید قبل از بک آپ گیری باشه
                service.Save("Asdasd");
                
            }
            catch (System.Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.Message.ToString());
            }
        }


        public string Title
        {
            get { return saleMali.CurrentSalMali; }
            
        }
        private string _Result;

        public string Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                RaisePropertyChanged("Result");
            }
        }

        private RelayCommand<Window> _Change;

        public RelayCommand<Window> Change
        {
            get
            {
                return _Change ?? (_Change = new RelayCommand<Window>(
                    (p) =>
                    {
                        SalMaliView sd = new SalMaliView();
                        sd.Show();
                        p.Close();
                    }
                    ));
            }
        }

        private RelayCommand _Load;

        public RelayCommand Load
        {
            get
            {
                return _Load ?? (_Load = new RelayCommand(
                    () =>
                    {
                        
                        Result = service.GetDatabaseInfo() + "\r\n";
                    }
                    ));
            }
        }
        private RelayCommand<Window> _Backup;

        public RelayCommand<Window> Backup
        {
            get
            {
                return _Backup ?? (_Backup = new RelayCommand<Window>(
                    (p) =>
                    {
                        saleMali.ChangeSalMali("temp");
                        System.Windows.Forms.Application.Restart();
                        System.Windows.Application.Current.Shutdown();
                    }
                    ));
            }
        }

        public class ConnectionDatabase
        {
            //private SaleMali saleMali;
            //public ConnectionDatabase(SaleMali _saleMali) 
            //{
            //    saleMali = _saleMali;
            //}

            public string GetSalMaliDatabaseLocation(string salMali)
            {
                string databaseDefaultPath = AppDomain.CurrentDomain.BaseDirectory;
                string databaseNameWithExtension = salMali + ".mdf";
                return databaseDefaultPath + databaseNameWithExtension;
            }

            //بخاطر این به کلاس تبدیل نشد که فقط اینجا تغییر دیتابیس داریم 
            public void ConfigDatabaseConnection(string salMali)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Clear();
                //config.ConnectionStrings.ConnectionStrings.Add(
                //    new ConnectionStringSettings("CString", getConnectionString(databaseName), "System.Data.SqlServerCe.4.0"));
                config.ConnectionStrings.ConnectionStrings.Add(
                    new ConnectionStringSettings("CString", getConnectionString(salMali), "System.Data.SqlClient"));
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
            }

            private string getConnectionString(string salMali)
            {
                string databaseDefaultPath = AppDomain.CurrentDomain.BaseDirectory;
                string databaseNameWithExtension = salMali + ".mdf";
                //var path = databaseName + ".sdf";
                //return "Data Source=|DataDirectory|\\" + path;
                return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + databaseDefaultPath + databaseNameWithExtension
                    + ";Integrated Security=True;Connect Timeout=30";
            }
        }
    }
}