using FitApp.BusinessLogic;
using System;
using Xamarin.Forms;

namespace FitApp.ViewModels.BmiViewModel
{
    public class BmiViewModel : BaseViewModel
    {
        #region Fields

        private double? weightEntry;
        private double? heightEntry;
        private double bmi;
        private double yourBmi;

        #endregion

        #region Properties

        public double? WeightEntry
        {
            get => weightEntry;
            set => SetProperty(ref weightEntry, value);
        }

        public double? HeightEntry
        {
            get => heightEntry;
            set => SetProperty(ref heightEntry, value);
        }

        public double Bmi
        {
            get => bmi;
            set => SetProperty(ref bmi, value);
        }
        public double YourBmi
        {
            get => yourBmi;
            set => SetProperty(ref yourBmi, value);
        }

        public Command SetBmi { get; }

        #endregion

        #region Constructor

        public BmiViewModel()
        {
            SetYourBmiLabel();
            SetBmi = new Command(SetBmiLabel);
        }

        #endregion

        #region Methods

        public void SetBmiLabel()
        {
            Bmi = Math.Round((double)CalculateBmi.CalculateBmiMethod(WeightEntry, HeightEntry),2);
        }

        public void SetYourBmiLabel()
        {
            YourBmi = Math.Round((double)CalculateBmi.GetYourBmi(1),2);
        }

        #endregion

    }
}
