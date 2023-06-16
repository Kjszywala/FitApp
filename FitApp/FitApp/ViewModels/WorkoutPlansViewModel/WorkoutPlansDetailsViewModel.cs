using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.ViewModels.WorkoutsViewModel;
using FitApp.Views.WorkoutPlanView;
using FitApp.Views.WorkoutView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutPlansViewModel
{
    internal class WorkoutPlansDetailsViewModel : AItemDatailsViewModel<WorkoutPlans>
    {
        #region Fields

        private string planName;
        private string planDescription;
        private string planDuration;
        private string planDifficulty;
        private string selectedUserName;
        private Users selectedUser;
        private List<Users> users;
        private UserModelService userModelService;

        #endregion

        #region Properties

        public string PlanName
        {
            get => planName;
            set => SetProperty(ref planName, value);
        }

        public string PlanDescription
        {
            get => planDescription;
            set => SetProperty(ref planDescription, value);
        }

        public string PlanDuration
        {
            get => planDuration;
            set => SetProperty(ref planDuration, value);
        }

        public string PlanDifficulty
        {
            get => planDifficulty;
            set => SetProperty(ref planDifficulty, value);
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

        public ObservableCollection<WorkoutPlans> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion

        #region Constructor

        public WorkoutPlansDetailsViewModel()
            : base()
        {
            userModelService = new UserModelService();
            userModelService.RefreshListFromService();
            users = userModelService.items;

            Items = new ObservableCollection<WorkoutPlans>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #endregion

        #region Methods

        public override async void LoadProperties(WorkoutPlans item)
        {
            PlanName = item.PlanName;
            PlanDescription = item.PlanDescription;
            PlanDuration = item.PlanDuration;
            PlanDifficulty = item.PlanDifficulty;
            SelectedUserName = (await userModelService.GetItemAsync(item.UserID.Value)).UserName;
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<WorkoutPlansService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.PlanId == ItemId).First();
            Item.PlanName = planName;
            Item.PlanDescription = planDescription;
            Item.PlanDuration = planDuration;
            Item.PlanDifficulty = planDifficulty;
            Item.UserID = selectedUser.UserID;
            Item.ModificationDate = DateTime.Now;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnEditSelected(int itemId)
        {
            var dataStore = DependencyService.Get<WorkoutPlansService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.PlanId == itemId).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(WorkoutPlanEditPage)}?{nameof(WorkoutPlansDetailsViewModel.ItemId)}={item.PlanId}");
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<WorkoutPlansService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.PlanId == this.ItemId);
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
