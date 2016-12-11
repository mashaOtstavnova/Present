using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using MvvmCross.Droid.Shared.Attributes;
using Fragment = Android.Support.V4.App.Fragment;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using Presents.Core.ViewModels;
using MvvmCross.Droid.Support.V4;

namespace Presents.Droid.Fragments
{
    [MvxFragment(typeof(HomeViewModel), Resource.Id.content_frame)]
    [Register("presents.droid.fragments.NewPresentFragment")]
    public class NewPresentFragment: MvxFragment<NewPresentViewModel>
    {
        public NewPresentFragment()
        {
            this.RetainInstance = true;
        }
        private ImageLoader imageLoader;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.new_present_fragment, null);
            var image = view.FindViewById<TextInputLayout>(Resource.Id.src_image_present);
            imageLoader = ImageLoader.Instance;
            imageLoader.DisplayImage("https://s.gravatar.com/avatar/7d1f32b86a6076963e7beab73dddf7ca?s=250", view.FindViewById<ImageView>(Resource.Id.profile_image));

            view.FindViewById<ImageView>(Resource.Id.profile_image).Click += (sender, args) =>
            {
                var builder = new NotificationCompat.Builder(Activity)
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetContentTitle("Click to go to friend details!")
                .SetContentText("New Friend!!");

                //var friendActivity = new Intent(Activity, typeof(FriendActivity));

                //PendingIntent pendingIntent = PendingIntent.GetActivity(Activity, 0, friendActivity, 0);


               // builder.SetContentIntent(pendingIntent);
                builder.SetAutoCancel(true);
                var notificationManager =
                    (NotificationManager)Activity.GetSystemService(Context.NotificationService);
                notificationManager.Notify(0, builder.Build());
            };
            return view;
        }

        /*var pendingIntent = Android.App.TaskStackBuilder.Create(Activity)
                                     .AddNextIntentWithParentStack(friendActivity)
                                     .GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);*/
    }
}
