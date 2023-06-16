using FitApp.ViewModels.ExerciseViewModel;
using FitApp.ViewModels.WorkoutExercisesViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutExerciseView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutExerciseEditPage : ContentPage
    {
        public WorkoutExerciseEditPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutExercisesDetailsViewModel();
        }
    }
}