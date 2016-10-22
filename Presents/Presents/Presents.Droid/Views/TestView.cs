using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Presents.Core.ViewModels;

namespace Presents.Droid.Views
{
    [Activity]
    public class TestView : BaseView<TestViewModel>
    {

        protected override int LayoutResource => Resource.Layout.TestView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // ViewModel.Hello = "test";
            ViewModel.Title = "Presents";
            Title = ViewModel.Title;
            
        }
    }
}