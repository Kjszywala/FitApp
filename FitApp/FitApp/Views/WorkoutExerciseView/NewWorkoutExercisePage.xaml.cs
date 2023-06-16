using FitApp.ViewModels.WorkoutExercisesViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutExerciseView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWorkoutExercisePage : ContentPage
    {
        public NewWorkoutExercisePage()
        {
            InitializeComponent();
            BindingContext = new NewWorkoutExercisesViewModel();
        }
    }
}