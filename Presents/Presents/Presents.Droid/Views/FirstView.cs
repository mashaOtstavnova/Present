using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Content;
using Android.Widget;
using Presents.Core.ViewModels;
using Presents.Droid.Extensions;
using VKontakte;
using VKontakte.API;

namespace Presents.Droid.Views
{
    /// <summary>
    ///     Activity which displays a login screen to the user, offering registration as well.
    /// </summary>
    [Register("presents.maria.firstview")]
    [IntentFilter(new[] { Intent.ActionView }, DataScheme = "vk5656833", Categories = new[]
    {
        Intent.CategoryBrowsable,
        Intent.CategoryDefault
    })]
    [Activity(WindowSoftInputMode = SoftInput.AdjustResize)]
    public class FirstView : BaseView<FirstViewModel>
    { // Scope is set of required permissions for your application
        // (see vk.com api permissions documentation: https://vk.com/dev/permissions)
        private static readonly string[] _myScopes =
        {
            VKScope.Friends,
            VKScope.Wall,
            VKScope.Photos,
            VKScope.Nohttps,
            VKScope.Messages,
            VKScope.Docs
        };

        private bool _isResumed;
        protected override int LayoutResource => Resource.Layout.login_view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.Hide();

            VKSdk.WakeUpSession(this, OnSucsessResult, OnErrorResult);

            var vkLoginButton = FindViewById<Button>(Resource.Id.page_login_vkLogin);
            vkLoginButton.Click += VkLoginButtonOnClick;
        }

        private void VkLoginButtonOnClick(object sender, EventArgs eventArgs)
        {
            ShowLogin();
        }

        private void OnErrorResult(VKError vkError)
        {
            //TODO: показывать ошибку диалогом
        }

        private void OnSucsessResult(VKSdk.LoginState loginState)
        {
            if (_isResumed)
                
            {
                if (loginState == VKSdk.LoginState.LoggedOut)
                {
                    ShowLogin();
                }
                else if (loginState == VKSdk.LoginState.LoggedIn)
                {
                    ViewModel.ShowMainPageCommand.Execute();
                }
            }
        }

        private void ShowLogin()
        {
            VKSdk.Login(this, _myScopes);
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (StoreExtensions.IsVkUserAuthorized(PackageName))
            {
               
                _isResumed = true;
                if (VKSdk.IsLoggedIn)
                {
                    ViewModel.ShowMainPageCommand.Execute();
                }
                else
                {
                    ShowLogin();
                }
            }
        }

        protected override void OnPause()
        {
            _isResumed = false;

            base.OnPause();
        }

        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            bool vkResult;
            var task = VKSdk.OnActivityResultAsync(requestCode, resultCode, data, out vkResult);
            if (!vkResult)
            {
                base.OnActivityResult(requestCode, resultCode, data);
            }

            try
            {
                var token = await task;

                Console.WriteLine("User passed Authorization: " + token.AccessToken);

                ViewModel.ShowMainPageCommand.Execute();

                StoreExtensions.SetVkUserAuthorized(PackageName);
            }
            catch (VKException ex)
            {
                Console.WriteLine("User didn't pass Authorization: " + ex);
            }
        }
    }
}