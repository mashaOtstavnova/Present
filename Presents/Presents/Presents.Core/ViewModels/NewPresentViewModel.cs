namespace Presents.Core.ViewModels
{
    public class NewPresentViewModel : BaseViewModel
    {
        private string _name;
        private string _description;
        private decimal _price;
        private byte[] _presentImage;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged(() => Price);
            }
        }

        public byte[] PresentImage
        {
            get { return _presentImage; }
            set
            {
                _presentImage = value;
                RaisePropertyChanged(() => PresentImage);
            }
        }
    }
}