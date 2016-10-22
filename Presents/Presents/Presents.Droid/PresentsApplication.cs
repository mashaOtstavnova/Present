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
using Presents.Droid.Views;
using VKontakte;
using VKontakte.Utils;

namespace Presents.Droid
{
    [Application(Name = "presents.presents")]
    public class PresentsApplication : Application
    {
        private readonly TokenTracker _tokenTracker = new TokenTracker();

        protected PresentsApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            // list the app fingerprints
            var fingerprints = VKUtil.GetCertificateFingerprint(this, PackageName);
            foreach (var fingerprint in fingerprints)
            {
                Console.WriteLine("Detected Fingerprint: " + fingerprint);
            }

            // setup VK
            _tokenTracker.StartTracking();
            VKSdk.Initialize(this).WithPayments();
        }

        private class TokenTracker : VKAccessTokenTracker
        {
            public override void OnVKAccessTokenChanged(VKAccessToken oldToken, VKAccessToken newToken)
            {
                if (newToken == null)
                {
                    //TODO: возможно придется делать через ViewDispather.ShowViewModel<>
                    Toast.MakeText(Context, "AccessToken invalidated", ToastLength.Long).Show();
                    var intent = new Intent(Context, typeof(FirstView));
                    intent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ClearTop);
                    Context.StartActivity(intent);
                }
            }
        }
    }
}