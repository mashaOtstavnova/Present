using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using Presents.Core.ViewModels;

namespace Presents.Droid.Fragments
{
    [MvxFragment(typeof(HomeViewModel), Resource.Id.content_frame)]
    [Register("presents.droid.fragments.NewPresentFragment")]
    public class NewPresentFragment : MvxFragment<NewPresentViewModel>
    {
        public static readonly int PickImageId = 1000;
        private ImageView _presentImageView;
        private ImageLoader imageLoader;
        private View view;

        public NewPresentFragment()
        {
            RetainInstance = true;
        }

        public Intent Intent { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            view = inflater.Inflate(Resource.Layout.new_present_fragment, null);
            _presentImageView = view.FindViewById<ImageView>(Resource.Id.present_image);
            imageLoader = ImageLoader.Instance;
            var imageUri = "drawable://" + Resource.Drawable.present;
            imageLoader.DisplayImage(imageUri, _presentImageView);

            _presentImageView.Click += (sender, args) =>
            {
                Intent = new Intent();
                Intent.SetType("image/*");
                Intent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(Intent.CreateChooser(Intent, "Выберите изображение"), PickImageId);
            };

            var addButton = view.FindViewById<Button>(Resource.Id.button_add_present);
            addButton.Click += ButtonForAddPresent;
            return view;
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            if (requestCode == PickImageId && resultCode == (int) Result.Ok && data != null)
            {
                var uri = data.Data;
                _presentImageView.SetImageURI(uri);
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }


        private void ButtonForAddPresent(object sender, EventArgs e)
        {
            _presentImageView.DrawingCacheEnabled = true;
            _presentImageView.BuildDrawingCache();
            var bitmap = _presentImageView.DrawingCache;

            var ms = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Png, 0, ms);
            ViewModel.PresentImage = ms.ToArray();
        }
    }
}