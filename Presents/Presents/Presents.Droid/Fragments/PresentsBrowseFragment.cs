using System;
using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using Presents.Core.Domain;
using Presents.Core.ViewModels;
using Presents.Droid.adapters;
using FloatingActionButton = com.refractored.fab.FloatingActionButton;

namespace Presents.Droid.Fragments
{
    [MvxFragment(typeof (HomeViewModel), Resource.Id.content_frame)]
    [Register("presents.droid.fragments.PresentsBrowseFragment")]
    public class PresentsBrowseFragment : MvxFragment<PresentsBrowseViewModel>
    {
        private List<Present> _presents;
        private PresentsAdapter adapter;
        private ViewPager viewPager;

        public PresentsBrowseFragment()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.fragment_friends, null);

            // Create your application here
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            viewPager.OffscreenPageLimit = 4;
            var tabs = view.FindViewById<TabLayout>(Resource.Id.tabs);
            tabs.TabMode = TabLayout.ModeScrollable;
            //Since we are a fragment in a fragment you need to pass down the child fragment manager!
            adapter = new PresentsAdapter(ChildFragmentManager);

            var addButton = view.FindViewById<FloatingActionButton>(Resource.Id.fab);
            var set = this.CreateBindingSet<PresentsBrowseFragment, PresentsBrowseViewModel>();
            set.Bind(addButton).To(vm => vm.AddClickCommand);
            set.Apply();

            addButton.Click += AddButtonClick;

            viewPager.Adapter = adapter;
            tabs.SetupWithViewPager(viewPager);

            return view;
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            ViewModel.AddClickCommand.Execute();
        }
    }
}