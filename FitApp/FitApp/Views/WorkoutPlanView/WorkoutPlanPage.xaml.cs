using FitApp.ViewModels.UsersViewModel;
using FitApp.ViewModels.WorkoutPlansViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutPlanView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutPlanPage : ContentPage
    {
        private WorkoutPlansViewModel _viewModel;
        public WorkoutPlanPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WorkoutPlansViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}