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

namespace Presents.Droid.Views
{
    [Activity(Label = "Nav Drawer", LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/ic_launcher")]
    public class HomeView : BaseView<HomeViewModel>
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        protected override int LayoutResource => Resource.Layout.page_home_view;

        protected override void OnCreate(Bundle bundle)
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
            nameUser.Text = "First Name";
            imageLoader.DisplayImage("http://lh6.ggpht.com/-Y4RkgMjWkFM/UgJ1eY2KcoI/AAAAAAACA2Q/dDvuuwV0rfQ/wI0DT5JxLZs_thumb%25255B1%25255D.jpg?imgmax=800", photoUser );

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);

                //switch (e.MenuItem.ItemId)
                //{
                //    case Resource.Id.nav_home:
                //        ViewModel.ShowBrowse();
                //        break;
                //    case Resource.Id.nav_friends:
                //        ViewModel.ShowFriends();
                //        break;
                //    case Resource.Id.nav_profile:
                //        ViewModel.ShowProfile();
                //        break;
                //}



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