using FitApp.ViewModels.Abstract;
using FitApp.Views.WorkoutView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutsViewModel
{
    public class WorkoutsViewModel : AListViewModel<Workouts>
    {
        public WorkoutsViewModel()
            : base("Workout")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewWorkoutPage));
        }

        public override async void OnItemSelected(Workouts item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(WorkoutDetailsPage)}?{nameof(WorkoutsDetailsViewModel.ItemId)}={item.WorkoutID}");
        }
    }
}

