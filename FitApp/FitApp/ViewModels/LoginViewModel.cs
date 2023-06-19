using FitApp.Services;
using FitApp.Views;
using FitApp.Views.ExerciseView;
using Xamarin.Forms;

namespace FitApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private UserModelService userModelService;
        private string login;
        private string password;
        private string error;

        #endregion

        #region Properties

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
        }

        public Command RegisterCommand { get; }
        public Command LoginCommand { get; }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            userModelService = new UserModelService();
            RegisterCommand = new Command(OnRegisterClicked);
            LoginCommand = new Command(OnLoginClicked);
        }

        #endregion

        #region Methods

        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        private async void OnLoginClicked(object obj)
        {
            var user = userModelService.GetItemsAsync().Result;
            foreach(var item in user)
            {
                if (item.UserName.Contains(Login))
                {
                    if(item.Password == Password)
                    {
                        Config.IsLoggedIn = true;
                        Config.UserId = item.UserID;
                        await Shell.Current.GoToAsync($"//{nameof(ExercisePage)}");
                    }
                    else
                    {
                        Error = "Wrong login or password!";
                    }
                }
            }
        }

        #endregion
    }
}
