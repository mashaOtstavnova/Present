using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class BaseViewModel:MvxViewModel
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }
    }
}