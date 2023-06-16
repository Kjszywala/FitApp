using FitApp.ViewModels.WorkoutPlansViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutPlanView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutPlanEditPage : ContentPage
    {
        public WorkoutPlanEditPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutPlansDetailsViewModel();
        }
    }
}