using Xamarin.Forms;

namespace Theatre.Controls
{
    [ContentProperty("Content")]
    public class StateCondition : Xamarin.Forms.View
    {
        public object State { get; set; }
        public Xamarin.Forms.View Content { get; set; }
    }
}