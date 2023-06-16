using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.WorkoutExerciseView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutExercisesViewModel
{
    public class WorkoutExercisesDetailsViewModel : AItemDatailsViewModel<WorkoutExercises>
    {
        #region Fields

        private int workoutExerciseId;
        private string sets;
        private string reps;
        private string weight;
        private string selectedExerciseName;
        private string selectedWorkoutName;
        private Exercises selectedExercise;
        private List<Exercises> exercises;
        private Workouts selectedWorkout;
        private List<Workouts> workouts;
        private ExerciseService exerciseService;
        private WorkoutService workoutService;

        #endregion

        #region Properties

        public string Sets
        {
            get => sets;
            set => SetProperty(ref sets, value);
        }

        public string Reps
        {
            get => reps;
            set => SetProperty(ref reps, value);
        }

        public string Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public string SelectedExerciseName
        {
            get => selectedExerciseName;
            set => SetProperty(ref selectedExerciseName, value);
        }

        public string SelectedWorkoutName
        {
            get => selectedWorkoutName;
            set => SetProperty(ref selectedWorkoutName, value);
        }

        public Exercises SelectedExercise
        {
            get => selectedExercise;
            set => SetProperty(ref selectedExercise, value);
        }
        public List<Exercises> Exercises
        {
            get
            {
                return exercises;
            }
        }
        public Workouts SelectedWorkout
        {
            get => selectedWorkout;
            set => SetProperty(ref selectedWorkout, value);
        }
        public List<Workouts> Workouts
        {
            get
            {
                return workouts;
            }
        }
        public ObservableCollection<WorkoutExercises> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion

        #region Constructor

        public WorkoutExercisesDetailsViewModel()
            : base()
        {
            exerciseService = new ExerciseService();
            exerciseService.RefreshListFromService();
            exercises = exerciseService.items;

            workoutService = new WorkoutService();
            workoutService.RefreshListFromService();
            workouts = workoutService.items;

            Items = new ObservableCollection<WorkoutExercises>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            AddSinCommand = new Command(async () => await OnEditSelected(ItemId));
        }

        #endregion

        #region Methods

        public override async void LoadProperties(WorkoutExercises item)
        {
            Sets = item.Sets;
            Reps = item.Reps;
            Weight = item.Weight;
            SelectedExerciseName = (await exerciseService.GetItemAsync(item.ExerciseID.Value)).ExerciseName;
            SelectedWorkoutName = (await workoutService.GetItemAsync(item.WorkoutID.Value)).WorkoutName;
            this.CopyProperties(item);
            await ExecuteLoadItemsCommand();
        }

        public override async void OnUpdateAsync()
        {
            var dataStore = DependencyService.Get<WorkoutExercisesService>();
            var Item = (await dataStore.GetItemsAsync(true)).Where(item => item.WorkoutExerciseID == ItemId).First();
            Item.Sets = this.Sets;
            Item.Reps = this.Reps;
            Item.Weight = this.Weight;
            Item.ExerciseID = this.SelectedExercise.ExerciseID;
            Item.WorkoutID = this.SelectedWorkout.WorkoutID;
            Item.ModificationDate = DateTime.Now;
            await DataStore.UpdateItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnEditSelected(int id)
        {
            var dataStore = DependencyService.Get<WorkoutExercisesService>();
            var item = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.WorkoutExerciseID == id).First();
            LoadProperties(item);
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(WorkoutExerciseEditPage)}?{nameof(WorkoutExercisesDetailsViewModel.ItemId)}={item.WorkoutExerciseID}");
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var dataStore = DependencyService.Get<WorkoutExercisesService>();
                var items = (await dataStore.GetItemsAsync(true)).Where(item2 => item2.WorkoutExerciseID == ItemId);
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