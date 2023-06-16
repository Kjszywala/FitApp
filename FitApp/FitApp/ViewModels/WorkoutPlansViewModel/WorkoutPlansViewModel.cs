using FitApp.ViewModels.Abstract;
using FitApp.ViewModels.MealsViewModel;
using FitApp.Views.MealView;
using FitApp.Views.WorkoutPlanView;
using FitApp.Views.WorkoutView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutPlansViewModel
{
    public class WorkoutPlansViewModel : AListViewModel<WorkoutPlans>
    {
        public WorkoutPlansViewModel()
          : base("Workout Plans")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewWorkoutPlanPage));
        }

        public override async void OnItemSelected(WorkoutPlans item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(WorkoutPlanDetailsPage)}?{nameof(WorkoutPlansDetailsViewModel.ItemId)}={item.PlanId}");
        }
    }
}