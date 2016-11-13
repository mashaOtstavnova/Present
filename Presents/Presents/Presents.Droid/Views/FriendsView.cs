using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;
using Presents.Core.IServices;
using Presents.Core.ViewModels;

namespace Presents.Droid.Views
{
    [Activity]
    public class FriendsView : BaseView<FriendsViewModel>
    {
        protected override int LayoutResource => Resource.Layout.friends_view;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ViewModel.Title = "FriendsView";
            Title = ViewModel.Title;
       
        }
    }
}