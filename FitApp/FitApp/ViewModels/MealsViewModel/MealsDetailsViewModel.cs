using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.MealView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.MealsViewModel
{
    public class MealsDetailsViewModel : AItemDatailsViewModel<Meals>
    {
        #region Fields

        private string mealName;
        private string mealDescription;
        private string mealCalories;
        private string selectedUserName;
        private Users selectedUser;
        private List<Users> users;
        private UserModelService userModelService;

        #endregion

        #region Properties

        public string MealName
        {
            get => mealName;
            set => SetProperty(ref mealName, value);
        }

        public string MealDescription
        {
            get => mealDescription;
            set => SetProperty(ref mealDescription, value);
        }

        public string MealCalories
        {
            get => mealCalories;
            set => SetProperty(ref mealCalories, value);
        }

        public string SelectedUserName
        {
            get => selectedUserName;
            set => SetProperty(ref selectedUserName, value);
        }

        public Users SelectedUser
        {
            get => selectedUser;
            set => SetProperty(ref selectedUser, value);
        }
        public List<Users> Users
        {
            get
            {
                return users;
            }
        }

        public ObservableCollection<Meals> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion

        #region Constructor

        public MealsDetailsViewModel() 
            : base()
        {
            userModelService = new UserModelService();
            userModelService.RefreshListFromService();
            users = userModelService.items;

            Items = new ObservableCollection<Meals>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #endregion

        #region Methods

        public override async void LoadProperties(Meals item)
        {
            MealName = item.MealName;
            MealDescription = item.MealDescription;
            MealCalories = item.MealCalories;
            SelectedUserName = (await userModelService.GetItemAsync(item.UserID.Value)).UserName;
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<MealsModelService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.MealID == ItemId).First();
            Item.ModificationDate = DateTime.Now;
            Item.MealName = this.mealName;
            Item.MealDescription = this.mealDescription;
            Item.MealCalories = this.mealCalories;
            Item.UserID = this.selectedUser.UserID;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnEditSelected(int id)
        {
            var dataStore = DependencyService.Get<MealsModelService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.MealID == id).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(MealEditPage)}?{nameof(MealsDetailsViewModel.ItemId)}={item.MealID}");
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<MealsModelService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.MealID == this.ItemId);
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
        #endregion
    }
}
