using FitApp.ViewModels.Abstract;
using FitApp.Views.WorkoutExerciseView;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutExercisesViewModel
{
    public class WorkoutExercisesViewModel : AListViewModel<WorkoutExercises>
    {
        public WorkoutExercisesViewModel()
            : base("Workout Exercises")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewWorkoutExercisePage));
        }

        public override async void OnItemSelected(WorkoutExercises item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(WorkoutExerciseDetailsPage)}?{nameof(WorkoutExercisesDetailsViewModel.ItemId)}={item.WorkoutExerciseID}");
        }
    }
}