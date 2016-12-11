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
            ShowViewModel<PresentsBrowseViewModel>();
        }
        public IMvxCommand AddClickCommand
        {
            get { return new MvxCommand(OnClickAdd); }
        }

        private void OnClickAdd()
        {
        }
    }
}