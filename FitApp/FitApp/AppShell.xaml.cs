using FitApp.Views;
using FitApp.Views.ExerciseView;
using FitApp.Views.FoodItemView;
using FitApp.Views.MealFoodItemView;
using FitApp.Views.MealView;
using FitApp.Views.UserView;
using FitApp.Views.WorkoutExerciseView;
using FitApp.Views.WorkoutPlanView;
using FitApp.Views.WorkoutView;
using System;
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

            Routing.RegisterRoute(nameof(WorkoutEditPage), typeof(WorkoutEditPage));
            Routing.RegisterRoute(nameof(WorkoutDetailsPage), typeof(WorkoutDetailsPage));
            Routing.RegisterRoute(nameof(NewWorkoutPage), typeof(NewWorkoutPage));

            Routing.RegisterRoute(nameof(NewWorkoutPlanPage), typeof(NewWorkoutPlanPage));
            Routing.RegisterRoute(nameof(WorkoutPlanDetailsPage), typeof(WorkoutPlanDetailsPage));
            Routing.RegisterRoute(nameof(WorkoutPlanEditPage), typeof(WorkoutPlanEditPage));

            Routing.RegisterRoute(nameof(NewWorkoutExercisePage), typeof(NewWorkoutExercisePage));
            Routing.RegisterRoute(nameof(WorkoutExerciseEditPage), typeof(WorkoutExerciseEditPage));
            Routing.RegisterRoute(nameof(WorkoutExerciseDetailsPage), typeof(WorkoutExerciseDetailsPage));

            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Config.IsLoggedIn = false;
            Config.UserId = 0;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
