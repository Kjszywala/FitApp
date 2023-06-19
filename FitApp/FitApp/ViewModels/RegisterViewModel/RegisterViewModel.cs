using FitApp.Services;
using FitApp.Views;
using FitAppApi;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.RegisterViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Fields

        private int id;
        private string userName;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private string gender;
        private int age;
        private decimal weight;
        private decimal height;
        private string activityLevel;
        private string error;
        private UserModelService userModelService;

        #endregion Fields

        #region Properties

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public int Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        public decimal Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public decimal Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }

        public string ActivityLevel
        {
            get => activityLevel;
            set => SetProperty(ref activityLevel, value);
        }

        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
        }

        public Command RegisterUser { get; }
        public Command CancelCommand { get; }
        #endregion

        #region Constructor

        public RegisterViewModel()
        {
            userModelService = new UserModelService();
            RegisterUser = new Command(async () => await RegisterAsync());
            CancelCommand = new Command(async () => await OnCancel());
        }

        #endregion

        #region Methods

        public async Task RegisterAsync()
        {
            var users = userModelService.GetItemsAsync().Result;
            foreach(var item in users)
            {
                if(item.UserName.Trim() == UserName.Trim())
                {
                    Error = "User name already exist!";
                    return;
                }
            }
            var user = new Users()
            {
                CreationDate = DateTime.Now,
                UserName = this.UserName,
                Password = this.Password,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Gender = this.Gender,
                Age = this.Age,
                Weight = (double)this.Weight,
                Height = (double)this.Height,
                ActivityLevel = this.ActivityLevel,
                IsActive = true,
                ModificationDate = DateTime.Now,

                Notes = "New item",
                Title = "User"
            };
            await userModelService.AddItemAsync(user);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public async Task OnCancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        #endregion

    }
}
