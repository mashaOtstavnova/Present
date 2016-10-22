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

namespace Presents.Droid.Extensions
{
    public static class StoreExtensions
    {
        public static void SetVkUserAuthorized(string packpageName)
        {
            var prefs = Application.Context.GetSharedPreferences(packpageName, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutBoolean("isVkUserAuthorized", true);
            prefEditor.Commit();
        }

        public static bool IsVkUserAuthorized(string packpageName)
        {
            var preferences = Application.Context.GetSharedPreferences(packpageName, FileCreationMode.Private);
            var value = preferences.GetBoolean("isVkUserAuthorized", false);
            return value;
        }
    }
}