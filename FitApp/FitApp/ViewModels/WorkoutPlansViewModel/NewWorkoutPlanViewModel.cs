using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutPlansViewModel
{
    public class NewWorkoutPlanViewModel : ANewViewModel<WorkoutPlans>
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

        public NewWorkoutPlanViewModel() : base()
        {
            userModelService = new UserModelService();
            userModelService.RefreshListFromService();
            users = userModelService.items;
        }

        #endregion

        public override WorkoutPlans SetItem()
        {
            var workoutPlan =  new WorkoutPlans
            {
                PlanName = this.PlanName,
                PlanDescription = this.PlanDescription,
                PlanDuration = this.PlanDuration,
                PlanDifficulty = this.PlanDifficulty,
                UserID = this.SelectedUser.UserID,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IsActive = true
            }.CopyProperties(this);
            return workoutPlan;
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(PlanName);
        }
    }
}