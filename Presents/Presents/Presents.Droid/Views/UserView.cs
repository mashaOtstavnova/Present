using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using MvvmCross.Platform;
using Presents.Core.IServices;
using Presents.Core.ViewModels;
using VKontakte.API;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Presents.Droid.Views
{
    [Activity(Label = "Friend", ParentActivity = typeof (HomeView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "navdrawer.activities.HomeView")]
    public class UserView : BaseView<UserViewModel>
    {
        private ImageLoader _imageLoader;
        protected override int LayoutResource => Resource.Layout.user_view;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // SetContentView(LayoutResource);
            ViewModel.Title = "UserView";
            Title = ViewModel.Title;

            _imageLoader = ImageLoader.Instance;

            IGetProfileService profileService;
            var service = Mvx.TryResolve(out profileService);

            var user = await profileService.GetUsers();

            //friends = Util.GenerateFriends();
            var title = user.first_name + " " + user.last_name;
            var birthday = user.bdate;

            title = string.IsNullOrWhiteSpace(title) ? "New Friend" : title;
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            //if (string.IsNullOrWhiteSpace(image))
            //    image = friends[0].Image;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            var collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolbar.SetTitle(title);
            _imageLoader.DisplayImage(user.photo_max_orig, FindViewById<ImageView>(Resource.Id.friend_image));


            var birthdayTextView = FindViewById<TextView>(Resource.Id.birthday);
            birthdayTextView.Text = birthday;
            var cityTextView = FindViewById<TextView>(Resource.Id.city);
            cityTextView.Text = user.city.title;
        }

        private void OnRequestComplete(VKResponse obj)
        {
            var r = obj.Json;
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