using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_UserControlCommandBinding
{
    public class MainViewModel
    {
        public ICommand ButtonCommand { get; set; }
        public MainViewModel()
        {
            ButtonCommand = new RelayCommand(() => { MessageBox.Show("Left Clicked"); });
        }
    }
}
