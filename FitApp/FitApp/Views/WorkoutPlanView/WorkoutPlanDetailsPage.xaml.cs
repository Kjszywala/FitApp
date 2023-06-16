using FitApp.ViewModels.WorkoutPlansViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutPlanView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutPlanDetailsPage : ContentPage
    {
        public WorkoutPlanDetailsPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutPlansDetailsViewModel();
        }
    }
}