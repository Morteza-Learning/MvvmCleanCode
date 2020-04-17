using Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmCleanCode.Properties;
using System.IO;
using System.Windows;
using static MvvmCleanCode.ViewModel.MainViewModel;

namespace MvvmCleanCode.ViewModel
{
    public class BackUpViewModel : ViewModelBase
    {
        //ConnectionDatabase c;
        public BackUpViewModel()
        {
            //c = new ConnectionDatabase();
            //c.ConfigDatabaseConnection("temp");
            //_service.Save("Temp data");
            //Result = "hghfgf";
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


        private RelayCommand<Window> _BackUp;

        public RelayCommand<Window> BackUp
        {
            get
            {
                return _BackUp ?? (_BackUp = new RelayCommand<Window>(
                    (p) =>
                    {
                        try
                        {
                            ConnectionDatabase c = new ConnectionDatabase();
                            var currentPath = c.GetSalMaliDatabaseLocation("1400");
                            Result = currentPath;
                            if (File.Exists(currentPath))
                            {
                                FileInfo Sourcefile = new FileInfo(currentPath);
                                Sourcefile.CopyTo("c:\\back.mdf", true);
                                Result = "File Is Ok";
                            }
                            else
                            {
                                Result = "Not Found : " + currentPath;
                            }
                        }
                        catch (System.Exception rt)
                        {

                            Result = rt.Message.ToString();
                        }
                        //System.Windows.Forms.Application.Restart();
                        //System.Windows.Application.Current.Shutdown();
                    }
                    ));
            }
        }
    }
}