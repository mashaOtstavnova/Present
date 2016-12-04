using Android.Support.V4.App;
using Java.Lang;
using Presents.Droid.Fragments;

namespace Presents.Droid.adapters
{
    public class PresentsAdapter : FragmentPagerAdapter
    {
        private static readonly string[] Content =
        {
            "Желанные", "Нежеланные"
        };

        public PresentsAdapter(FragmentManager p0)
            : base(p0)
        {
        }

        public override int Count
        {
            get { return Content.Length; }
        }

        public override Fragment GetItem(int index)
        {
            switch (index)
            {
                case 0:
                    return new PresentsAllFragment();
                case 1:
                    return new PresentsRecentFragment();
            }

            return new PresentsAllFragment();
        }

        public override ICharSequence GetPageTitleFormatted(int p0)
        {
            return new String(Content[p0%Content.Length].ToUpper());
        }
    }
}