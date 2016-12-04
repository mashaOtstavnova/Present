using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using Java.Lang;
using Presents.Core.Domain;

namespace Presents.Droid.adapters
{
    internal class PresentAdapterWrapper : Object
    {
        public TextView Title { get; set; }
        public ImageView Art { get; set; }
    }

    public class PresentAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly IEnumerable<Present> presents;

        public PresentAdapter(Activity context, IEnumerable<Present> presents)
        {
            this.context = context;
            this.presents = presents;
            ImageLoader = ImageLoader.Instance;
        }

        public ImageLoader ImageLoader { get; set; }

        public override bool HasStableIds
        {
            get { return true; }
        }

        public override int Count
        {
            get { return presents.Count(); }
        }

        public override Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (position < 0)
                return null;

            var view = (convertView
                        ?? context.LayoutInflater.Inflate(
                            Resource.Layout.item_present, parent, false)
                );

            if (view == null)
                return null;

            var wrapper = view.Tag as PresentAdapterWrapper;
            if (wrapper == null)
            {
                wrapper = new PresentAdapterWrapper
                {
                    Title = view.FindViewById<TextView>(Resource.Id.item_title),
                    Art = view.FindViewById<ImageView>(Resource.Id.item_image)
                };
                view.Tag = wrapper;
            }

            var present = presents.ElementAt(position);

            wrapper.Title.Text = present.Title;

            wrapper.Art.SetImageResource(Android.Resource.Color.Transparent);
            ImageLoader.DisplayImage(present.Image, wrapper.Art);
            return view;
        }
    }
}