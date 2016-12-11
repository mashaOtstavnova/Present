using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presents.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { SetProperty(ref _hello, value); }
        }
        public void ShowInfo()
        {
            ShowViewModel<InfoViewModel>();
        }
        public void ShowSettings()
        {
            ShowViewModel<NewPresentViewModel>();
        }

        public void ShowFriends()
        {
            ShowViewModel<FriendsViewModel>();
        }

        public void ShowProfile()
        {
            ShowViewModel<UserViewModel>();
        }
    }
   
}
