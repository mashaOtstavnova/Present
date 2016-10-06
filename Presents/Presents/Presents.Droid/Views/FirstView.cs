using Android.App;
using Android.OS;
using Presents.Core.ViewModels;

namespace Presents.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView<FirstViewModel>
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //теперь можно взять вьюмодель в любом месте автивити
            // ViewModel.Hello = "test";
            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}