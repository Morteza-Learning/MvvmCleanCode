using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmCleanCode.Properties;
using System.Windows;

namespace MvvmCleanCode.ViewModel
{
    public class SaleMaliViewModel : ViewModelBase
    {
        public SaleMaliViewModel()
        {
            salmal = Settings.Default.DatabaseName;
        }

        private string myVar;

        public string salmal
        {
            get { return myVar; }
            set
            {
                myVar = value;
                RaisePropertyChanged("salmal");
            }
        }

        private RelayCommand<Window> _changeSal;

        public RelayCommand<Window> changeSal
        {
            get
            {
                return _changeSal ?? (_changeSal = new RelayCommand<Window>(
                    (p) =>
                    {
                        Settings.Default.DatabaseName = salmal;
                        Settings.Default.Save();
                        Settings.Default.Reload();

                        System.Windows.Forms.Application.Restart();
                        System.Windows.Application.Current.Shutdown();
                    }
                    ));
            }
        }
    }
}