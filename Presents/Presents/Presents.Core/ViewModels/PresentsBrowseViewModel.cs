using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class PresentsBrowseViewModel : MvxViewModel
    {
        public IMvxCommand AddClickCommand
        {
            get { return new MvxCommand(OnClickAdd); }
        }

        private void OnClickAdd()
        {
        }
    }
}