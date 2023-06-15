using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.Generic;

namespace FitApp.ViewModels.MealsViewModel
{
    public class NewMealViewModel : ANewViewModel<Meals>
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
            set 
            { 
                SetProperty(ref selectedUser, value); 
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public List<Users> Users
        {
            get
            {
                return users;
            }
        }

        #endregion

        #region Constructor

        public NewMealViewModel() : base() 
        {
            userModelService = new UserModelService();
            userModelService.RefreshListFromService();
            users = userModelService.items;
        }

        #endregion

        public override Meals SetItem()
        {
            return new Meals
            {
                MealName = this.MealName,
                MealDescription = this.MealDescription,
                MealCalories = this.MealCalories,
                UserID = this.selectedUser.UserID,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IsActive = true
            }.CopyProperties(this);
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(MealName);
        }
    }
}
