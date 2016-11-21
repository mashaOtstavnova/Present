using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform;
using Presents.Core.IServices;
using Presents.Core.ViewModels;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Presents.Droid.Views
{
    [Activity(Label = "Friends", ParentActivity = typeof(HomeView))]
    public class FriendsView : BaseView<FriendsViewModel>
    {
        protected override int LayoutResource => Resource.Layout.friends_view;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ViewModel.Title = "Äðóçüÿ";
            Title = ViewModel.Title;
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //if (string.IsNullOrWhiteSpace(image))
            //    image = friends[0].Image;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:

                    try
                    {
                        NavUtils.NavigateUpFromSameTask(this);
                    }
                    catch (Exception ex)
                    {
                        var m = ex.Message;
                    }
                    
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}