using MvvmCross.Core.ViewModels;

namespace Presents.Core.ViewModels
{
    public class FirstViewModel
        : BaseViewModel
    {
        //private string _hello = "Hello MvvmCross";
        //public string Hello
        //{
        //    get { return _hello; }
        //    set { SetProperty(ref _hello, value); }
        //}
        private string _login;
        private string _password;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                RaisePropertyChanged(() => Login);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public IMvxCommand ShowMainPageCommand
        {
            get { return new MvxCommand(ShowMainPage); }
        }

        private void ShowMainPage()
        {
            ShowViewModel<TestViewModel>();
            //if (_repository.Users.Any(human => human.Login == Login && human.Password == Password))
            //{
            //    var user =
            //        FakeData.Users.FirstOrDefault(human => human.Login == Login && human.Password == Password);
            //    _repository.CurrentUser = user;
            //    switch (user.Type)
            //    {
            //        case UserType.Administrator:
            //            ShowViewModel<TeachersViewModel>();
            //            break;
            //        case UserType.Teacher:
            //            ShowViewModel<ScheduleViewModel>();
            //            break;
            //        case UserType.Student:
            //            ShowViewModel<ScheduleViewModel>();
            //            break;
            //    }
            //}
            //else
            //{
            //    _notificationService.ShowNotification("Ошибка авторизации",
            //        "Пользователя с такими данными не существует в базе!");
            //}
        }
    }
}
