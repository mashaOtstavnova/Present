using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public IMvxCommand ShowPresents
        {
            get { return new MvxCommand(ShowCommandPresents); }
        }

        private void ShowCommandPresents()
        {
            ShowViewModel<PresentsViewModel>();
        }
    }
}
