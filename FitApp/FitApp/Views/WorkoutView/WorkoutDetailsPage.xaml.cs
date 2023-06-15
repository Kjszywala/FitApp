using FitApp.ViewModels.UsersViewModel;
using FitApp.ViewModels.WorkoutsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.WorkoutView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDetailsPage : ContentPage
    {
        public WorkoutDetailsPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutsDetailsViewModel();
        }
    }
}