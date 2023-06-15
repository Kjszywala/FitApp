using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.UserView;
using FitAppApi;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.UsersViewModel
{
    public class UserDetailsViewModel : AItemDatailsViewModel<Users>
    {
        public UserDetailsViewModel()
            : base()
        {
            Items = new ObservableCollection<Users>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

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

        public ObservableCollection<Users> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion Properties

        public override async void LoadProperties(Users item)
        {
            UserName = item.UserName;
            Password = item.Password;
            Email = item.Email;
            FirstName = item.FirstName;
            LastName = item.LastName;
            Gender = item.Gender;
            Age = item.Age;
            Weight = (decimal)item.Weight;
            Height = (decimal)item.Height;
            ActivityLevel = item.ActivityLevel;

            Title = "User Details";
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<UserModelService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item => item.UserID == Id);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task OnEditSelected(int id)
        {
            var dataStore = DependencyService.Get<UserModelService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.UserID == id).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(UserEditPage)}?{nameof(UserDetailsViewModel.ItemId)}={item.UserID}");
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<UserModelService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.UserID == ItemId).First();
            Item.ModificationDate = DateTime.Now;
            Item.UserName = this.UserName;
            Item.Password = this.Password;
            Item.Email = this.Email;
            Item.FirstName = this.FirstName;
            Item.LastName = this.LastName;
            Item.Gender = this.Gender;
            Item.Age = this.Age;
            Item.Weight = (double)this.Weight;
            Item.Height = (double)this.Height;
            Item.ActivityLevel = this.ActivityLevel;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }
    }
}