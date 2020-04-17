using MvvmCleanCode.ViewModel;
using System.Windows;

namespace MvvmCleanCode
{
    /// <summary>
    /// Interaction logic for BackUpView.xaml
    /// </summary>
    public partial class BackUpView : Window
    {
        public BackUpView()
        {
            InitializeComponent();
            DataContext = new BackUpViewModel();
        }
    }
}
