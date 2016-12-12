using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class PresentsBrowseViewModel : BaseViewModel
    {
        public IMvxCommand AddClickCommand
        {
            get { return new MvxCommand(OnClickAdd); }
        }

        private void OnClickAdd()
        {
            ShowViewModel<NewPresentViewModel>();
        }
    }
}