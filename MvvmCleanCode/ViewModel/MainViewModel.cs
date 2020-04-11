using Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Forms;



namespace MvvmCleanCode.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private IService service;
       
        public MainViewModel(IService _service)
        {
            Title = "I Am Default Title";
            var p = Properties.Settings.Default.DatabaseName;
            DatabaseChanger.ChangeDatabaseNameTo(p);
            service = _service;
            service.Save("I Am "+ p + " Title");
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

        private RelayCommand _Change;

        public RelayCommand Change
        {
            get
            {
                return _Change ?? (_Change = new RelayCommand(
                    () =>
                    {
                        Properties.Settings.Default.DatabaseName = "1399";
                        Properties.Settings.Default.Save();

                        Application.Restart();
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