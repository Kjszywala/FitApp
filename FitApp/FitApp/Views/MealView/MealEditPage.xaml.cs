using FitApp.ViewModels.MealFoodItemsViewModel;
using FitApp.ViewModels.MealsViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.MealView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealEditPage : ContentPage
    {
        public MealEditPage()
        {
            InitializeComponent();
            BindingContext = new MealsDetailsViewModel();
        }
    }
}