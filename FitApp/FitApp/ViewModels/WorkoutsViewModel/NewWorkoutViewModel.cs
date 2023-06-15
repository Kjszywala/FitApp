using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitApp.Views.WorkoutView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitApp.ViewModels.WorkoutsViewModel
{
    public class NewWorkoutViewModel : ANewViewModel<Workouts>
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

        #endregion

        #region Constructor

        public NewWorkoutViewModel() : base()
        {
            planModelService = new WorkoutPlansService();
            planModelService.RefreshListFromService();
            plans = planModelService.items;
        }

        #endregion

        public override Workouts SetItem()
        {
            return new Workouts
            {
                WorkoutName = this.WorkoutName,
                WorkoutDescription = this.WorkoutDescription,
                WorkoutDuration = this.WorkoutDuration,
                WorkoutDifficulty = this.WorkoutDifficulty,
                PlanID = this.selectedPlan.PlanId,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IsActive = true
            }.CopyProperties(this);
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(WorkoutName);
        }
    }
}