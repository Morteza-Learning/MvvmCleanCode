using Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmCleanCode.Properties;
using System.IO;
using System.Windows;

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
                service = _service;
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
        private RelayCommand _Backup;

        public RelayCommand Backup
        {
            get
            {
                return _Backup ?? (_Backup = new RelayCommand(
                    () =>
                    {
                        //if (File.Exists(saleMali.getCurrentSalMaliDatabaseLocation()))
                        //{
                        //    FileInfo Sourcefile = new FileInfo(saleMali.getCurrentSalMaliDatabaseLocation());
                        //    Sourcefile.CopyTo("c:\\", true);
                        //    Result = "File Is Ok";
                        //}
                    }
                    ));
            }
        }
    }
}