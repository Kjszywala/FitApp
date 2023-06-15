using FitApp.ViewModels.MealFoodItemsViewModel;
using FitApp.ViewModels.MealsViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.MealView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealPage : ContentPage
    {
        private MealsViewModel _viewModel;
        public MealPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MealsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}