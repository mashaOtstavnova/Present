using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using Presents.Core.Domain;
using Presents.Core.ViewModels;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Presents.Droid.Views
{
    [Activity(Label = "Presents", ParentActivity = typeof (UserView))]
    [MetaData("android.support.PARENT_ACTIVITY", Value = "presents.droid.views.HomeView")]
    public class PresentsView : BaseView<PresentsViewModel>
    {
        private ImageLoader imageLoader;
        private List<Present> presents;
        protected override int LayoutResource => Resource.Layout.page_presents;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // ViewModel.Hello = "test";
            ViewModel.Title = "Presents";
            Title = ViewModel.Title;

            imageLoader = ImageLoader.Instance;

            presents = new List<Present>();
            presents.Add(new Present
            {
                Title = "Title",
                Details = "Datails",
                Id = 25,
                Image = "https://cs7060.vk.me/c604316/v604316689/384b0/H9NOko56g6o.jpg"
            });

            //friends = Util.GenerateFriends();
            var title = Intent.GetStringExtra("Title");
            var image = Intent.GetStringExtra("Image");
            var details = Intent.GetStringExtra("Details");

            title = string.IsNullOrWhiteSpace(title) ? "New Friend" : title;
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            if (string.IsNullOrWhiteSpace(image))
                image = presents[0].Image;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var collapsingToolbar = FindViewById<CollapsingToolbarLayout>(Resource.Id.collapsing_toolbar);
            collapsingToolbar.SetTitle(title);

            imageLoader.DisplayImage(image, FindViewById<ImageView>(Resource.Id.friend_image));


            var detailsTextView = FindViewById<TextView>(Resource.Id.details);
            detailsTextView.Text = details;
        }

        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(this, typeof (PresentsView));
            intent.PutExtra("Title", presents[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", presents[itemClickEventArgs.Position].Image);
            intent.PutExtra("Details", presents[itemClickEventArgs.Position].Details);
            StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:

                    NavUtils.NavigateUpFromSameTask(this);


                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}