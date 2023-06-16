using FitApp.ViewModels.WorkoutsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutEditPage : ContentPage
    {
        public WorkoutEditPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutsDetailsViewModel();
        }
    }
}