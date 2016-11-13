using Android.App;
using Android.OS;
using Presents.Core.ViewModels;

namespace Presents.Droid.Views
{
    [Activity]
    public class InfoView : BaseView<InfoViewModel>
    {
        protected override int LayoutResource => Resource.Layout.info_view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ViewModel.Title = "InfoView";
            Title = ViewModel.Title;
        }
    }
}