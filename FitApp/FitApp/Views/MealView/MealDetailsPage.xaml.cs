using FitApp.ViewModels.MealsViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.MealView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealDetailsPage : ContentPage
    {
        public MealDetailsPage()
        {
            InitializeComponent();
            BindingContext = new MealsDetailsViewModel();
        }
    }
}