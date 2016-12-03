using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class FriendViewModel : BaseViewModel
    {
        public int IdFriend { get; set; }
        public void Init(int idFriend)
        {
            IdFriend = idFriend;
        }
        public IMvxCommand ShowMainPageCommand
        {
            get { return new MvxCommand(ShowMainPage); }
        }

        private void ShowMainPage()
        {
            ShowViewModel<HomeViewModel>();
        }
    }
}
