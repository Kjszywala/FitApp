using FitApp.ViewModels.Abstract;
using FitApp.Views.MealView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.MealsViewModel
{
    public class MealsViewModel : AListViewModel<Meals>
    {
        public MealsViewModel()
          : base("Meals")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewMealPage));
        }

        public override async void OnItemSelected(Meals item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(MealDetailsPage)}?{nameof(MealsDetailsViewModel.ItemId)}={item.MealID}");
        }
    }
}
