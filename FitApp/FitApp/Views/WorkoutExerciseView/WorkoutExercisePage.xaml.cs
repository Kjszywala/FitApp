using FitApp.ViewModels.WorkoutExercisesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutExerciseView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutExercisePage : ContentPage
    {
        private WorkoutExercisesViewModel _viewModel;
        public WorkoutExercisePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WorkoutExercisesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}