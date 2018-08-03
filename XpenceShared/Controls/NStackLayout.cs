using Xamarin.Forms;

namespace XpenceShared.Controls
{
    public class NStackLayout:StackLayout
    {
        public NStackLayout():base()
        {
            if (Device.RuntimePlatform == Device.iOS)
                Margin = new Thickness(0, 20, 0, 0);
        }
    }
}