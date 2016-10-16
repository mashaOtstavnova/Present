using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Presents.Droid.Views
{
    public abstract class BaseView<TModel> : MvxAppCompatActivity<TModel> where TModel : class, IMvxViewModel
    {
        //этот вроде по желанию
        protected Toolbar Toolbar { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);//для статус бара (для андройда начитая с 5)
            SetContentView(LayoutResource);
            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }

        //нужно переопределять на каждом актвивити
        protected abstract int LayoutResource { get; }
    }
}
