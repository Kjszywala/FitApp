using FitApp.Services;
using FitApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<ExerciseService>();
            DependencyService.Register<FoodItemService>();
            DependencyService.Register<MealFoodItemService>();
            DependencyService.Register<MealsModelService>();
            DependencyService.Register<UserModelService>();
            DependencyService.Register<WorkoutExercisesService>();
            DependencyService.Register<WorkoutPlansService>();
            DependencyService.Register<WorkoutService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
