using System.Windows.Input;
using Xamarin.Forms;

namespace Theatre.ViewModel
{
    public class DemoViewModel
    {
        public States State { get; set; } = States.Normal;
        
        public ICommand LoadDataCommand => new Command(Load);

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
            Normal,
        }
    }

}