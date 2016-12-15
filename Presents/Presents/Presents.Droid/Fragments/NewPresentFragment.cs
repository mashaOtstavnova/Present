using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using Presents.Core.ViewModels;

namespace Presents.Droid.Fragments
{
    [MvxFragment(typeof (HomeViewModel), Resource.Id.content_frame)]
    [Register("presents.droid.fragments.NewPresentFragment")]
    public class NewPresentFragment : MvxFragment<NewPresentViewModel>
    {
        private ImageLoader imageLoader;
        private View view;

        public NewPresentFragment()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.new_present_fragment, null);
            var image = view.FindViewById<TextInputLayout>(Resource.Id.src_image_present);
            imageLoader = ImageLoader.Instance;
            var imageUri = "drawable://" + Resource.Drawable.present;
            imageLoader.DisplayImage(imageUri, view.FindViewById<ImageView>(Resource.Id.profile_image));

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
                    (NotificationManager) Activity.GetSystemService(Context.NotificationService);
                notificationManager.Notify(0, builder.Build());
            };
            var addButton = view.FindViewById<Button>(Resource.Id.button_add_present);
            addButton.Click += ButtonForAddPresent;
            return view;
        }

        private void ButtonForAddPresent(object sender, EventArgs e)
        {
            var image = view.FindViewById<TextInputLayout>(Resource.Id.src_image_present).EditText;
            var name = view.FindViewById<TextInputLayout>(Resource.Id.name_present).EditText;
            ;
            var description = view.FindViewById<TextInputLayout>(Resource.Id.description_present).EditText;
            ;
        }
    }
}