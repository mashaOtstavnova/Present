using Android.App;
using Android.OS;
using Presents.Core.ViewModels;

namespace Presents.Droid.Views
{
    [Activity]
    public class SettingsView : BaseView<SettingsViewModel>
    {
        protected override int LayoutResource => Resource.Layout.setting_view;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ViewModel.Title = "SettingsView";
            Title = ViewModel.Title;
        }
    }
}