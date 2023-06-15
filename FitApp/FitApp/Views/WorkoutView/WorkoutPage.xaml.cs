using FitApp.ViewModels.WorkoutsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutPage : ContentPage
    {
        private WorkoutsViewModel _viewModel;
        public WorkoutPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WorkoutsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}