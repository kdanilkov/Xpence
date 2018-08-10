using Prism.Events;
using Prism.Navigation;
using Xamarin.Forms;
using XpenceShared.Events;

namespace Xpence.Views
{
    public partial class RootPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public RootPage(IEventAggregator ea)
        {
            InitializeComponent();
            ea?.GetEvent<ShowMenuEvent>().Subscribe((newState) => {
                IsPresented = newState;
            });
        }
        public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
    }
}