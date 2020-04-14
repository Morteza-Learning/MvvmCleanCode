using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmCleanCode.Properties;
using System.Windows;

namespace MvvmCleanCode.ViewModel
{
    public class SaleMaliViewModel : ViewModelBase
    {
        SaleMali salMali;
        public SaleMaliViewModel()
        {
            salMali = new SaleMali();
            salmal = salMali.CurrentSalMali;
        }

        public string salmal { get; set; }
        

        private RelayCommand<Window> _changeSal;

        public RelayCommand<Window> changeSal
        {
            get
            {
                return _changeSal ?? (_changeSal = new RelayCommand<Window>(
                    (p) =>
                    {
                        salMali.CurrentSalMali = salmal;

                        System.Windows.Forms.Application.Restart();
                        System.Windows.Application.Current.Shutdown();
                    }
                    ));
            }
        }
    }
}