using FitApp.ViewModels.BmiViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitApp.Views.BmiView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BmiPage : ContentPage
    {
        public BmiPage()
        {
            InitializeComponent();
            BindingContext = new BmiViewModel();
        }
    }
}