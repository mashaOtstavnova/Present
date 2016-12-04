using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using Presents.Core.Domain;
using Presents.Core.ViewModels;
using Presents.Droid.adapters;
using Presents.Droid.Views;

namespace Presents.Droid.Fragments
{
    [MvxFragment(typeof (HomeViewModel), Resource.Id.content_frame)]
    [Register("presents.droid.fragments.FriendsAllFragment")]
    public class PresentsAllFragment : MvxFragment<PresentsAllViewModel>
    {
        private List<Present> presents;

        public PresentsAllFragment()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.fragments_presents_all, null);
            var grid = view.FindViewById<GridView>(Resource.Id.grid);
            presents = new List<Present>
            {
                new Present
                {
                    Title = "Title",
                    Details = "Datails",
                    Id = 25,
                    Image = "https://cs7060.vk.me/c604316/v604316689/384b0/H9NOko56g6o.jpg"
                }
            };

            grid.Adapter = new PresentAdapter(Activity, presents);
            grid.ItemClick += GridOnItemClick;
            return view;
        }

        private void GridOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(Activity, typeof (PresentsView));
            intent.PutExtra("Title", presents[itemClickEventArgs.Position].Title);
            intent.PutExtra("Image", presents[itemClickEventArgs.Position].Image);
            StartActivity(intent);
        }
    }
}