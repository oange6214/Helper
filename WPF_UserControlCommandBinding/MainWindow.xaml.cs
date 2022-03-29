using Common;
using System.Windows;
using System.Windows.Input;

namespace WPF_UserControlCommandBinding
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void DemoUserControl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("CLICK");
        }

        public ICommand ClickCommand => new RelayCommand(Canvas_MouseMove);
        private void Canvas_MouseMove()
        {
            
        }
    }
}
