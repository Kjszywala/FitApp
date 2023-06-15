using FitApp.ViewModels;
using FitApp.ViewModels.WorkoutsViewModel;
using FitApp.Views;
using FitApp.Views.ExerciseView;
using FitApp.Views.FoodItemView;
using FitApp.Views.MealFoodItemView;
using FitApp.Views.MealView;
using FitApp.Views.UserView;
using FitApp.Views.WorkoutView;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FitApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewExercisePage), typeof(NewExercisePage));
            Routing.RegisterRoute(nameof(ExerciseDetailsPage), typeof(ExerciseDetailsPage));
            Routing.RegisterRoute(nameof(ExerciseEditPage), typeof(ExerciseEditPage));

            Routing.RegisterRoute(nameof(NewFoodItemPage), typeof(NewFoodItemPage));
            Routing.RegisterRoute(nameof(FoodItemDetailsPage), typeof(FoodItemDetailsPage));
            Routing.RegisterRoute(nameof(FoodItemEditPage), typeof(FoodItemEditPage));

            Routing.RegisterRoute(nameof(NewMealFoodItemPage), typeof(NewMealFoodItemPage));
            Routing.RegisterRoute(nameof(MealFoodItemDetailsPage), typeof(MealFoodItemDetailsPage));
            Routing.RegisterRoute(nameof(MealFoodItemEditPage), typeof(MealFoodItemEditPage));
            
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
            Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));
            Routing.RegisterRoute(nameof(UserEditPage), typeof(UserEditPage));

            Routing.RegisterRoute(nameof(NewMealPage), typeof(NewMealPage));
            Routing.RegisterRoute(nameof(MealDetailsPage), typeof(MealDetailsPage));
            Routing.RegisterRoute(nameof(MealEditPage), typeof(MealEditPage));

            Routing.RegisterRoute(nameof(WorkoutPage), typeof(WorkoutPage));
            Routing.RegisterRoute(nameof(WorkoutDetailsPage), typeof(WorkoutDetailsPage));
            Routing.RegisterRoute(nameof(NewWorkoutPage), typeof(NewWorkoutPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
