namespace CreateMapSample.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Main = new MainViewModel();
        }


        private MainViewModel _main;

        public MainViewModel Main
        {
            get { return _main; }
            set { _main = value; }
        }


        //public event PropertyChangedEventHandler PropertyChanged;
        //public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
