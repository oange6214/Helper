using Common;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Delegate_Event
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EventHandler demoEvent;

        public delegate void MyEventHandler();



        public MainWindow()
        {
            InitializeComponent();

            //Task.Run(() =>
            //{
            //    try
            //    {
            //        Counter c = new Counter();
            //        c.ThresholdReached += test_method;
            //        c.Call();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //});

            //MyEventHandler = test_method


        }

        void MyMethod()
        {
            MessageBox.Show("MyMethod");
        }

        void test_method(object sender, EventArgs e)
        {
                MessageBox.Show($"{sender as Counter2}完成 test_method");
            }
        }

    public class Counter
    {
        public void Call()
        {

            ThresholdReached?.Invoke(new Counter2(), EventArgs.Empty);
        }

        public event EventHandler ThresholdReached;
    }

    public class Counter2
    {
        public void Call()
        {
            ThresholdReached?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ThresholdReached;
    }
}
