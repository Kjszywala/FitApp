using FitApp.Helpers;
using FitApp.Services;
using FitApp.ViewModels.Abstract;
using FitAppApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FitApp.ViewModels.WorkoutExercisesViewModel
{
    public class NewWorkoutExercisesViewModel : ANewViewModel<WorkoutExercises>
    {
        #region Fields

        private int workoutExerciseId;
        private string sets;
        private string reps;
        private string weight;
        private string selectedExerciseName;
        private string selectedWorkoutName;
        private Exercises selectedExercise;
        private List<Exercises> exercises;
        private Workouts selectedWorkout;
        private List<Workouts> workouts;

        #endregion

        #region Properties

        public string Sets
        {
            get => sets;
            set => SetProperty(ref sets, value);
        }

        public string Reps
        {
            get => reps;
            set => SetProperty(ref reps, value);
        }

        public string Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public Exercises SelectedExercise
        {
            get => selectedExercise;
            set => SetProperty(ref selectedExercise, value);
        }
        public List<Exercises> Exercises
        {
            get
            {
                return exercises;
            }
        }
        public Workouts SelectedWorkout
        {
            get => selectedWorkout;
            set => SetProperty(ref selectedWorkout, value);
        }
        public List<Workouts> Workouts
        {
            get
            {
                return workouts;
            }
        }

        public ObservableCollection<WorkoutExercises> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddSinCommand { get; }

        #endregion

        #region Constructor

        public NewWorkoutExercisesViewModel()
            : base()
        {
            selectedExercise = new Exercises();
            selectedWorkout = new Workouts();

            var exercisesDataStorage = new ExerciseService();
            exercisesDataStorage.RefreshListFromService();
            exercises = exercisesDataStorage.items;

            var workoutsDataStorage = new WorkoutService();
            workoutsDataStorage.RefreshListFromService();
            workouts = workoutsDataStorage.items;

            Items = new ObservableCollection<WorkoutExercises>();
        }

        #endregion
        #region Methods

        public override WorkoutExercises SetItem()
        {
            var item = new WorkoutExercises()
            {
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                IsActive = true,
                Sets = this.Sets,
                Reps = this.Reps,
                Weight = this.Weight,
                ExerciseID = this.SelectedExercise.ExerciseID,
                WorkoutID = this.SelectedWorkout.WorkoutID,
                Title = this.Title,
                Notes = "Ćwiczyć i nie obijać się"
            }.CopyProperties(this);
            return item;
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(Sets);
        }

        #endregion

    }
}