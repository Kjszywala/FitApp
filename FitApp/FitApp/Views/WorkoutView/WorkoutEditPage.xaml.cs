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
    public partial class WorkoutEditPage : ContentPage
    {
        public WorkoutEditPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutsDetailsViewModel();
        }
    }
}