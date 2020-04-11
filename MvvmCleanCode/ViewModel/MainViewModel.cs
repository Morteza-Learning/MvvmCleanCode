using Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace MvvmCleanCode.ViewModel
{
   
    public class MainViewModel : ViewModelBase
    {
        private IService service;
       
        public MainViewModel(IService _service)
        {
            Title = "I Am Default Title";

            DatabaseChanger.ChangeDatabaseNameTo("1398");
            service = _service;
            service.Save("I Am 1398 Title");
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
                        DatabaseChanger.ChangeDatabaseNameTo("1399");
                        service.Save("I Am 1399 Title");
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