using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Theatre.Annotations;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class DemoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private States state; 
        public ICommand LoadDataCommand => new Command(Load);

        public States State
        {
            get { return state; }
            set
            {
                state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        private void Load()
        {
            State = States.Loading;
        }

        public DemoViewModel()
        {
            State = States.Normal;
        }

        public enum States
        {
            Loading,
            Normal
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }

}