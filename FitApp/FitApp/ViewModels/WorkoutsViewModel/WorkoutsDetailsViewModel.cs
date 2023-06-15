using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.MealView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
        private WorkoutPlanModelService planModelService;

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

        public string wWrkoutDifficulty
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
            planModelService = new WorkoutPlanModelService();
            planModelService.RefreshListFromService();

        }

        #endregion

        #region Methods

        public override void LoadProperties(Workouts item)
        {
            throw new NotImplementedException();
        }

        public override void OnUpdateAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
