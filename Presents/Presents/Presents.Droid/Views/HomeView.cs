using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using Presents.Core.ViewModels;
using Presents.Droid.Services;

namespace Presents.Droid.Views
{
    [Activity(Label = "Nav Drawer", LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/ic_launcher")]
    public class HomeView : BaseView<HomeViewModel>
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        protected override int LayoutResource => Resource.Layout.page_home_view;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // ViewModel.Hello = "test";
            ViewModel.Title = "Presents";
            Title = ViewModel.Title;
            var config = ImageLoaderConfiguration.CreateDefault(ApplicationContext);
            ImageLoader.Instance.Init(config);
            //// Initialize ImageLoader with configuration.
            ImageLoader imageLoader = ImageLoader.Instance;
            var headerMenu = this.FindViewById<NavigationView>(Resource.Id.nav_view).GetHeaderView(0);
          
            var photoUser = headerMenu.FindViewById<ImageView>(Resource.Id.user_image);
            var nameUser = headerMenu.FindViewById<TextView>(Resource.Id.user_name);
         

            var user = await GetProfileService.GetUsers();
            nameUser.Text = user.first_name +" "+user.last_name;
            imageLoader.DisplayImage(user.photo_max_orig, photoUser );

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_user:
                        ViewModel.ShowProfile();
                        break;
                    case Resource.Id.nav_friends:
                        ViewModel.ShowFriends();
                        break;
                    case Resource.Id.nav_settings:
                        ViewModel.ShowInfo();
                        break;
                    case Resource.Id.nav_info:
                        ViewModel.ShowInfo();
                        break;
                }



                drawerLayout.CloseDrawers();
            };

            ////if first time you will want to go ahead and click first item.
            //if (savedInstanceState == null)
            //{
            //    ViewModel.ShowBrowse();
            //}
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}