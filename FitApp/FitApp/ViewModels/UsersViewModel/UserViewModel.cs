using FitApp.ViewModels.Abstract;
using FitApp.Views.UserView;
using FitAppApi;
using Xamarin.Forms;

namespace FitApp.ViewModels.UsersViewModel
{
    public class UserViewModel : AListViewModel<Users>
    {
        public UserViewModel()
            : base("User")
        {
        }

        public override async void GoToAddPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(NewUserPage));
        }

        public override async void OnItemSelected(Users item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(UserDetailsPage)}?{nameof(UserDetailsViewModel.ItemId)}={item.UserID}");
        }
    }
}