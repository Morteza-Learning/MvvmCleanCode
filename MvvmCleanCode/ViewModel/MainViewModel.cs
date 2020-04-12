using Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmCleanCode.Properties;
using System.Windows;


namespace MvvmCleanCode.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private IService service;
       
        public MainViewModel(IService _service)
        {
            Title = Settings.Default.DatabaseName;

            var p = Settings.Default.DatabaseName;

            DatabaseChanger.ChangeDatabaseNameTo(p);
            service = _service;
            service.Save("I Am " + p + " Title");
        }

        private string myVar;

        public string Title
        {
            get { return myVar; }
            set 
            { 
                myVar = value;
                RaisePropertyChanged("Title");
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
                        Title = service.GetData();
                    }
                    ));
            }
        }
    }
}