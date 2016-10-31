using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using Presents.Core.ViewModels;


using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;


using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Presents.Droid.Views
{
    [Activity(Label = "Friend", ParentActivity = typeof(HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "navdrawer.activities.HomeView")]
    public class UserView : MvxAppCompatActivity<UserViewModel>
    {
        ImageLoader imageLoader;
        protected int LayoutResource => Resource.Layout.user_view;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(LayoutResource);
            ViewModel.Title = "UserView";
            Title = ViewModel.Title;

            imageLoader = ImageLoader.Instance;


            //friends = Util.GenerateFriends();
            var title = "Title";
            var details = "Detailse";

            title = string.IsNullOrWhiteSpace(title) ? "New Friend" : title;
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //if (string.IsNullOrWhiteSpace(image))
            //    image = friends[0].Image;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolbar.SetTitle(title);

            imageLoader.DisplayImage("http://lh6.ggpht.com/-Y4RkgMjWkFM/UgJ1eY2KcoI/AAAAAAACA2Q/dDvuuwV0rfQ/wI0DT5JxLZs_thumb%25255B1%25255D.jpg?imgmax=800", FindViewById<ImageView>(Resource.Id.friend_image));


            var detailsTextView = FindViewById<TextView>(Resource.Id.details);
            detailsTextView.Text = details;
        }
        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            //var intent = new Intent(this, typeof(FriendActivity));
            //intent.PutExtra("Title", friends[itemClickEventArgs.Position].Title);
            //intent.PutExtra("Image", friends[itemClickEventArgs.Position].Image);
            //intent.PutExtra("Details", friends[itemClickEventArgs.Position].Details);
            //StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:

                    NavUtils.NavigateUpFromSameTask(this);

                    //Wrong:
                    //var intent = new Intent(this, typeof(HomeView));
                    //intent.AddFlags(ActivityFlags.ClearTop);
                    //StartActivity(intent);


                    //if this could be launched externally:

                    /*var upIntent = NavUtils.GetParentActivityIntent(this);
                    if (NavUtils.ShouldUpRecreateTask(this, upIntent))
                    {
                        // This activity is NOT part of this app's task, so create a new task
                        // when navigating up, with a synthesized back stack.
                        Android.Support.V4.App.TaskStackBuilder.Create(this).
                            AddNextIntentWithParentStack(upIntent).StartActivities();
                    }
                    else
                    {
                        // This activity is part of this app's task, so simply
                        // navigate up to the logical parent activity.
                        NavUtils.NavigateUpTo(this, upIntent); 
                    }*/

                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}