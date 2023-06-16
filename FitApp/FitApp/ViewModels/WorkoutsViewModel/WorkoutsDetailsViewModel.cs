using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.WorkoutView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutsViewModel
{
    public class WorkoutsDetailsViewModel : AItemDatailsViewModel<Workouts>
    {
        #region Fields

        private string workoutName;
        private string workoutDescription;
        private string workoutDuration;
        private string workoutDifficulty;
        private string selectedWorkoutName;
        private WorkoutPlans selectedPlan;
        private List<WorkoutPlans> plans;
        private WorkoutPlansService planModelService;

        #endregion

        #region Properties

        public string WorkoutName
        {
            get => workoutName;
            set => SetProperty(ref workoutName, value);
        }

        public string WorkoutDescription
        {
            get => workoutDescription;
            set => SetProperty(ref workoutDescription, value);
        }

        public string WorkoutDuration
        {
            get => workoutDuration;
            set => SetProperty(ref workoutDuration, value);
        }

        public string WorkoutDifficulty
        {
            get => workoutDifficulty;
            set => SetProperty(ref workoutDifficulty, value);
        }

        public string SelectedWorkoutName
        {
            get => selectedWorkoutName;
            set => SetProperty(ref selectedWorkoutName, value);
        }

        public WorkoutPlans SelectedPlan
        {
            get => selectedPlan;
            set => SetProperty(ref selectedPlan, value);
        }

        public List<WorkoutPlans> Plans
        {
            get
            {
                return plans;
            }
        }

        public ObservableCollection<Workouts> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion

        #region Constructor

        public WorkoutsDetailsViewModel()
            : base()
        {
            planModelService = new WorkoutPlansService();
            planModelService.RefreshListFromService();
            plans = planModelService.items;

            Items = new ObservableCollection<Workouts>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #endregion

        #region Methods

        public override async void LoadProperties(Workouts item)
        {
            WorkoutName = item.WorkoutName;
            WorkoutDescription = item.WorkoutDescription;
            WorkoutDuration = item.WorkoutDuration;
            WorkoutDifficulty = item.WorkoutDifficulty;
            SelectedWorkoutName = (await planModelService.GetItemAsync(item.PlanID.Value)).PlanName;
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<WorkoutService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.WorkoutID == ItemId).First();
            Item.ModificationDate = DateTime.Now;
            Item.WorkoutName = this.WorkoutName;
            Item.WorkoutDescription = this.WorkoutDescription;
            Item.WorkoutDuration = this.WorkoutDuration;
            Item.WorkoutDifficulty = this.WorkoutDifficulty;
            Item.PlanID = this.selectedPlan.PlanId;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnEditSelected(int itemId)
        {
            var dataStore = DependencyService.Get<WorkoutService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.WorkoutID == itemId).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(WorkoutEditPage)}?{nameof(WorkoutsDetailsViewModel.ItemId)}={item.WorkoutID}");
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<WorkoutService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.WorkoutID == this.ItemId);
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
