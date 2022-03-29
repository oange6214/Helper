using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace WPF_UserControlCommandBinding
{
    public partial class DemoUserControl : UserControl
    {
        public DemoUserControl()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent ClickEvent = ButtonBase.ClickEvent.AddOwner(typeof(DemoUserControl));

        public event RoutedEventHandler Click
        {
            add { button.AddHandler(ClickEvent, value); }
            remove { button.RemoveHandler(ClickEvent, value); }
        }
    }
}
