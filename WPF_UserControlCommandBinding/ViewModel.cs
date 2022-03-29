using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_UserControlCommandBinding
{
    public class ViewModel
    {
        public RelayCommand ClickCommand
        {
            get
            {
                return new RelayCommand(null)
                {

                };
            }
        }
    }
}
